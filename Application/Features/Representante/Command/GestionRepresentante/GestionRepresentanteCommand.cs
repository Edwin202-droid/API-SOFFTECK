using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Command.GestionRepresentante
{
    public class GestionRepresentanteCommand : IRequest<Response.Result>
    {
        public Guid? RepresentanteId { get; set; }
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
