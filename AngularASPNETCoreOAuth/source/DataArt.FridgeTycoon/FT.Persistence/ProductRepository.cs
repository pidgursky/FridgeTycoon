using FT.Domain.Entities.ProductAggregate;
using FT.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;

namespace FT.Persistence
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FTDBContext context) : base(context)
        {
        }
    }

}
