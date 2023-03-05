using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Query.GetNotas
{
    public class NotasVm
    {
        public Guid NotaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreRepresentante { get; set; }

    }
}
