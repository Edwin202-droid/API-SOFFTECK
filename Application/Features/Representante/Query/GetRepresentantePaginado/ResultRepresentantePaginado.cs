using Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Representante.Query.GetRepresentantePaginado
{
    public class ResultRepresentantePaginado
    {
        public List<RepresentantePaginado> records { get; set; }

        public PaginationMetadata paging { get; set; }
    }
}
