using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Query.GetNotaForId
{
    public class NotaForIdVm
    {
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreRepresentante { get; set; }
        public string Telefono { get; set; }
        public List<NotaForIdDetalle> Detalles { get; set; }
    }

    public class NotaForIdDetalle
    {
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
