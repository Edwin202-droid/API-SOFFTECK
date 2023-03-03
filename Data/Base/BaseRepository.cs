using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly SoftteckContext context;

        public BaseRepository(SoftteckContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            //await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        //public T GetById(Guid id)
        //{
        //    return context.Set<T>().Find(id);
        //}

        //public IReadOnlyList<T> ListAll()
        //{
        //    return context.Set<T>().ToList();
        //}

        //public T Add(T entity)
        //{
        //    context.Set<T>().Add(entity);

        //    return entity;
        //}

        //public virtual void Update(T entity, params Expression<Func<T, object>>[] properties)
        //{
        //    context.Update(entity);
        //}
    }
}
