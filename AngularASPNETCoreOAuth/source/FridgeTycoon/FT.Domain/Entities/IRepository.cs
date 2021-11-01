using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FT.Domain.Entities
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task CreateAsync(TEntity item);
        Task<TEntity> FindByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        void Remove(TEntity item);
        void Update(TEntity item);

    }
}
