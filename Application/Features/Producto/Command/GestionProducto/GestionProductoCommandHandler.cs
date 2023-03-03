using Application.Response;
using AutoMapper;
using Data.Base;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Producto.Command.GestionProducto
{
    public class GestionProductoCommandHandler : IRequestHandler<GestionProductoCommand, Result>
    {
        private readonly IProductoRepository productoRepository;
        private readonly IUnitOfWork unitOfWork;

        public GestionProductoCommandHandler(IProductoRepository productoRepository, IUnitOfWork unitOfWork)
        {
            this.productoRepository = productoRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(GestionProductoCommand request, CancellationToken cancellationToken)
        {
            using (var tx = unitOfWork.BeginTransaction())
            {
                try
                {
                    if (request.ProductoId == null)
                    {
                        var producto = new Domain.Entities.Producto
                        {
                            ProductoId = Guid.NewGuid(),
                            Nombre = request.Nombre,
                            Descripcion = request.Descripcion,
                            Precio = request.Precio
                        };
                        await productoRepository.AddAsync(producto);
                        if (await unitOfWork.Save() > 0)
                        {
                            tx.Commit();
                            return new Result { IsSuccess = true, Mensaje = "Producto creado correctamente." };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se pudo insertar el producto." };
                        }
                    }
                    else
                    {
                        var producto = await productoRepository.GetByIdAsync((Guid)request.ProductoId);


                        if (producto == null)
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se encontro el producto." };
                        }

                        producto.Nombre = request.Nombre;
                        producto.Descripcion = request.Descripcion;
                        producto.Precio = request.Precio;

                        await productoRepository.UpdateAsync(producto);
                        if (await unitOfWork.Save() > 0)
                        {
                            tx.Commit();
                            return new Result { IsSuccess = true, Mensaje = "Producto actualizado correctamente" };
                        }
                        else
                        {
                            return new Result { IsSuccess = false, Mensaje = "No se pudo actualizar el producto" };
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
