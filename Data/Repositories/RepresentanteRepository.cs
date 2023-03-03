using Data.Base;
using Data.Repositories_Interfaces;
using Domain.Entities;
using Helpers.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepresentanteRepository : BaseRepository<Representante>, IRepresentanteRepository
    {
        private readonly SoftteckContext softteckContext;

        public RepresentanteRepository(SoftteckContext softteckContext) : base(softteckContext)
        {
            this.softteckContext = softteckContext;
        }
        public PagedList<Representante> ListRepresentantePaginado(PagedRequest page)
        {
            var query = (from r in softteckContext.Representantes
                         join e in softteckContext.Empresas on r.EmpresaId equals e.EmpresaId
                         select new Representante
                         {
                             RepresentanteId  = r.RepresentanteId,
                             Nombre = r.Nombre,
                             NumeroDocumento = r.NumeroDocumento,
                             Telefono = r.Telefono,
                             Empresa = new Empresa
                             {
                                 EmpresaId = e.EmpresaId,
                                 Nombre = e.Nombre
                             }
                         });
            var queryPaged = PagedList<Representante>.Create(query, page.PageNumber, page.PageSize);
            return queryPaged;
        }

        public async Task<IReadOnlyList<Representante>> GetRepresentantes(Guid id)
        {
            var query = await (from r in softteckContext.Representantes
                               where r.EmpresaId == id
                               select r).ToListAsync();
            return query;
        }
    }
}
