using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IRepository<T>
    {
        //T GetById(Guid id);

        //IReadOnlyList<T> ListAll();

        //T Add(T entity);

        //void Update(T entity, params Expression<Func<T, object>>[] properties);

        Task<T> GetByIdAsync(Guid id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }
}
