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
    public class NotaDetalleRepository : BaseRepository<NotaDetalle>, INotaDetalleRepository
    {
        private readonly SoftteckContext softteckContext;

        public NotaDetalleRepository(SoftteckContext softteckContext) : base(softteckContext)
        {
            this.softteckContext = softteckContext;
        }
    }
}
