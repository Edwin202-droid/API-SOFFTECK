using Data.Base;
using Data.Repositories_Interfaces;
using Domain.Entities;
using Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        private readonly SoftteckContext softteckContext;

        public EmpresaRepository(SoftteckContext softteckContext) : base(softteckContext)
        {
            this.softteckContext = softteckContext;
        }

        public PagedList<Empresa> ListEmpresaPaginado(PagedRequest page)
        {
            var query = (from e in softteckContext.Empresas
                         select e);
            var queryPaged = PagedList<Empresa>.Create(query, page.PageNumber, page.PageSize);
            return queryPaged;
        }
    }
}
