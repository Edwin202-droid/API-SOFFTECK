using Application.Response;
using Data.Base;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Empresa.Command.GestionEmpresa
{
    public class GestionEmpresaCommandHandler : IRequestHandler<GestionEmpresaCommand, Result>
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IUnitOfWork unitOfWork;

        public GestionEmpresaCommandHandler(IEmpresaRepository empresaRepository, IUnitOfWork unitOfWork)
        {
            this.empresaRepository = empresaRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(GestionEmpresaCommand request, CancellationToken cancellationToken)
        {
            using (var tx = unitOfWork.BeginTransaction())
            {
                try
                {
                    if(request.EmpresaId == null)
                    {
                        var empresa = new Domain.Entities.Empresa
                        {
                            EmpresaId = Guid.NewGuid(),
                            Nombre = request.Nombre,
                            Telefono = request.Telefono,
                            Direccion = request.Direccion
                        };
                        await empresaRepository.AddAsync(empresa);
                        if(await unitOfWork.Save() > 0)
                        {
                            tx.Commit();
                            return new Result { IsSuccess = true, Mensaje = "Empresa creada correctamente." };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se pudo crear la empresa." };
                        }
                    }
                    else
                    {
                        var empresa = await empresaRepository.GetByIdAsync((Guid)request.EmpresaId);


                        if(empresa == null)
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se encontro la empresa." };
                        }

                        empresa.Nombre = request.Nombre;
                        empresa.Telefono = request.Telefono;    
                        empresa.Direccion = request.Direccion;
                        await empresaRepository.UpdateAsync(empresa);
                        if (await unitOfWork.Save() > 0)
                        {
                            tx.Commit();
                            return new Result { IsSuccess = true, Mensaje = "Empresa actualizada correctamente" };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se pudo actualizar la empresa" };
                        }

                    }
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return new Result { IsSuccess = false, Mensaje = "Ocurrio un error inesperado." };
                }
            }
        }
    }
}
