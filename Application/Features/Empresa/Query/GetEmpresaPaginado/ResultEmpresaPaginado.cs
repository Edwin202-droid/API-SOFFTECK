using Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Empresa.Query.GetEmpresaPaginado
{
    public class ResultEmpresaPaginado
    {
        public List<EmpresaPaginado> records { get; set; }

        public PaginationMetadata paging { get; set; }
    }
}
