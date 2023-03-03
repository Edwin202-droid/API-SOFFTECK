using Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Producto.Query.ProductoPaginado
{
    public class ResultProductoPaginado
    {
        public List<ProductoPaginadoVm> records { get; set; }

        public PaginationMetadata paging { get; set; }
    }
}
