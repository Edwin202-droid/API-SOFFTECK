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
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        private readonly SoftteckContext softteckContext;

        public ProductoRepository(SoftteckContext softteckContext) : base(softteckContext)
        {
            this.softteckContext = softteckContext;
        }

        public PagedList<Producto> ListProductoPaginado(PagedRequest page)
        {
            var query = (from e in softteckContext.Producto
                         select e);
            var queryPaged = PagedList<Producto>.Create(query, page.PageNumber, page.PageSize);
            return queryPaged;
        }
    }
}
