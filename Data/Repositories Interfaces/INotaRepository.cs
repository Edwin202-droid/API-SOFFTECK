using Data.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories_Interfaces
{
    public interface INotaRepository : IRepository<Nota>
    {
        Task<IReadOnlyList<Nota>> GetNotas();
    }
}
