using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Representante
    {
        [Key]
        public Guid RepresentanteId { get; set; }
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
