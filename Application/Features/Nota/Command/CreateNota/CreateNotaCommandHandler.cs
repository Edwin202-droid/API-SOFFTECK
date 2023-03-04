using Application.Response;
using Data.Base;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Command.CreateNota
{
    public class CreateNotaCommandHandler : IRequestHandler<CreateNotaCommand, Result>
    {
        private readonly INotaRepository notaRepository;
        private readonly INotaDetalleRepository notaDetalleRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateNotaCommandHandler(INotaRepository notaRepository, INotaDetalleRepository notaDetalleRepository,
            IUnitOfWork unitOfWork)
        {
            this.notaRepository = notaRepository;
            this.notaDetalleRepository = notaDetalleRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateNotaCommand request, CancellationToken cancellationToken)
        {
            using (var tx = unitOfWork.BeginTransaction())
            {
                try
                {
                    var nota = new Domain.Entities.Nota
                    {
                        Descripcion = request.Descripcion,
                        Total = request.Total,
                        RepresentanteId = request.RepresentanteId,
                        EmpresaId = request.EmpresaId,
                        UsuarioId = request.UsuarioId,
                    };

                    await notaRepository.AddAsync(nota);

                    var resultNota = await unitOfWork.Save();

                    foreach (var item in request.Detalles)
                    {
                        var detalle = new Domain.Entities.NotaDetalle
                        {
                            ProductoId = item.ProductoId,
                            NombreProducto = item.Nombre,
                            Cantidad = item.Cantidad,
                            Subtotal = item.Precio * item.Cantidad,
                        };

                        await notaDetalleRepository.AddAsync(detalle);

                        var resultNotaDetalle = await unitOfWork.Save();

                        if(resultNotaDetalle <= 0)
                        {
                            return new Result { IsSuccess = false, Mensaje = "Ocurrio un error inesperado." };
                        }
                    }

                    if(resultNota > 0)
                    {
                        tx.Commit();
                        return new Result { IsSuccess = true, Mensaje = "Nota creada correctamente." };
                    }
                    else
                    {
                        return new Result { IsSuccess = false, Mensaje = "No se pudo crear la nota." };

                    }

                }
                catch (Exception)
                {
                    tx.Rollback();
                    return new Result { IsSuccess = false, Mensaje = "Ocurrio un error inesperado." };
                }
            }
        }
    }
}
