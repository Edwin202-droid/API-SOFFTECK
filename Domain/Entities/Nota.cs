using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Nota
    {
        public Guid NotaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public Guid RepresentanteId { get; set; }
        public Representante Representante { get; set; }
        public List<NotaDetalle> NotaDetalles { get; set; }
    }
}
