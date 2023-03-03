using Data.Base;
using Data.Repositories_Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IReadOnlyList<Nota>> GetNotas()
        {
            var query = await (from n in softteckContext.Nota
                               join e in softteckContext.Empresas on n.EmpresaId equals e.EmpresaId
                               join r in softteckContext.Representantes on n.RepresentanteId equals r.RepresentanteId
                               select new Nota
                               {
                                   Descripcion = n.Descripcion,
                                   Total = n.Total,
                                   Empresa = new Empresa
                                   {
                                       Nombre = e.Nombre
                                   },
                                   Representante = new Representante
                                   {
                                       Nombre = r.Nombre
                                   }
                               }).ToListAsync();
            return query;
        }
    }
}
