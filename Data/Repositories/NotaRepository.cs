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


        public async Task<IReadOnlyList<Nota>> GetNotas(string usuarioId)
        {
            var query = await (from n in softteckContext.Nota
                               join e in softteckContext.Empresas on n.EmpresaId equals e.EmpresaId
                               join r in softteckContext.Representantes on n.RepresentanteId equals r.RepresentanteId
                               where n.UsuarioId == usuarioId
                               select new Nota
                               {
                                   NotaId = n.NotaId,
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

        public async Task<Nota> GetNotaForId(Guid notaId)
        {
            var query = await (from n in softteckContext.Nota
                               join e in softteckContext.Empresas on n.EmpresaId equals e.EmpresaId
                               join r in softteckContext.Representantes on n.RepresentanteId equals r.RepresentanteId
                               where n.NotaId == notaId
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
                                       Nombre = r.Nombre,
                                       Telefono = r.Telefono,
                                   },
                                   NotaDetalles = (from nd in softteckContext.NotaDetalle
                                                   where nd.NotaId == notaId
                                                   select nd).ToList()
                               }).FirstOrDefaultAsync();
            return query;
        }
    }
}
