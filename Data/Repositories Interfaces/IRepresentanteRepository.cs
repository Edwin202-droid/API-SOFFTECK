using Data.Base;
using Domain.Entities;
using Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories_Interfaces
{
    public interface IRepresentanteRepository : IRepository<Representante>
    {
        PagedList<Representante> ListRepresentantePaginado(PagedRequest page);
        Task<IReadOnlyList<Representante>> GetRepresentantes(Guid id);
    }
}
