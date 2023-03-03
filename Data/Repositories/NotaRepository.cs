using Data.Base;
using Data.Repositories_Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class NotaRepository : BaseRepository<Nota>, INotaRepository
    {
        private readonly SoftteckContext softteckContext;

        public NotaRepository(SoftteckContext softteckContext) : base(softteckContext)
        {
            this.softteckContext = softteckContext;
        }
    }
}
