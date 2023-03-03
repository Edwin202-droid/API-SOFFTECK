using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NotaDetalle
    {
        public Guid NotaDetalleId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public Guid ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public Guid NotaId { get; set; }
        public Nota Nota { get; set; }
    }
}
