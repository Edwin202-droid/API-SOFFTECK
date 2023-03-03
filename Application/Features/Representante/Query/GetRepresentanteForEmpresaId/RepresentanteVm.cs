using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Query.GetRepresentanteForEmpresaId
{
    public class RepresentanteVm
    {
        public Guid RepresentanteId { get; set; }
        public string Nombre { get; set; }
    }
}
