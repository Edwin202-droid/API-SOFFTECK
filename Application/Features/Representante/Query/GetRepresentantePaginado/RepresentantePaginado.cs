using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Query.GetRepresentantePaginado
{
    public class RepresentantePaginado
    {
        public Guid RepresentanteId { get; set; }
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string NombreEmpresa { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
