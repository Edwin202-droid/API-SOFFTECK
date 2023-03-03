using Application.Response;
using Data.Base;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Command.GestionRepresentante
{
    public class GestionRepresentanteCommandHandler : IRequestHandler<GestionRepresentanteCommand, Result>
    {
        private readonly IRepresentanteRepository representanteRepository;
        private readonly IUnitOfWork unitOfWork;

        public GestionRepresentanteCommandHandler(IRepresentanteRepository representanteRepository, IUnitOfWork unitOfWork)
        {
            this.representanteRepository = representanteRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(GestionRepresentanteCommand request, CancellationToken cancellationToken)
        {
            using (var tx = unitOfWork.BeginTransaction())
            {
                try
                {
                    if (request.RepresentanteId == null)
                    {
                        var representante = new Domain.Entities.Representante
                        {
                            RepresentanteId = Guid.NewGuid(),
                            Nombre = request.Nombre,
                            Telefono = request.Telefono,
                            NumeroDocumento = request.NumeroDocumento,
                            EmpresaId = request.EmpresaId,
                        };
                        await representanteRepository.AddAsync(representante);
                        if (await unitOfWork.Save() > 0)
                        {
                            tx.Commit();
                            return new Result { IsSuccess = true, Mensaje = "Representante creado correctamente." };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se pudo insertar al representante." };
                        }
                    }
                    else
                    {
                        var representante = await representanteRepository.GetByIdAsync((Guid)request.RepresentanteId);


                        if (representante == null)
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se encontro al representante." };
                        }

                        representante.Nombre = request.Nombre;
                        representante.Telefono = request.Telefono;
                        representante.NumeroDocumento = request.NumeroDocumento;
                        representante.EmpresaId = request.EmpresaId;
                        await representanteRepository.UpdateAsync(representante);
                        if (await unitOfWork.Save() > 0)
                        {
                            tx.Commit();
                            return new Result { IsSuccess = true, Mensaje = "Representante actualizada correctamente" };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se pudo actualizar al representante" };
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
