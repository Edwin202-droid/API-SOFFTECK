using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Command.CreateNota
{
    public class CreateNotaCommand : IRequest<Response.Result>
    {
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public Guid UsuarioId { get; set; }

        public Guid EmpresaId { get; set; }
        public Guid RepresentanteId { get; set; }
        public List<Detalles> Detalles { get; set; }
    }

    public class Detalles
    {
        public Guid ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Cantidad { get; set; }
    }
}
