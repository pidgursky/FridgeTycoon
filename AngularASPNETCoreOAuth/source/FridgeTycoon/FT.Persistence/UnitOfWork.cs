using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.ProductAggregate;
using FT.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FT.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private FTDBContext _dbContext;

        public UnitOfWork(FTDBContext _context, IConfiguration configuration)
        {
            this._dbContext = _context;
        }

        public Task<int> SaveAsync() => _dbContext.SaveChangesAsync();

    }
}
