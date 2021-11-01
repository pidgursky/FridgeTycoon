using FT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FT.Persistence
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private FTDBContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(FTDBContext context) 
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
         {
            IQueryable<TEntity> query = _dbSet;
             foreach (Expression<Func<TEntity, object>> include in includes)
             {
                query = query.Include(include);
             }
            return  await  query.Where(predicate).ToListAsync();

         }    


        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);

        }

        public async Task CreateAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);   

        }
        public void Update(TEntity item)
        {
             _context.Entry(item).State = EntityState.Modified;

        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);

        }
    }   
}
