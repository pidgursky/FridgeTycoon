using System.Threading;
using System.Threading.Tasks;
using FT.Domain.Entities;
using FT.Persistence;
using System.Collections.Generic;
using FT.Domain.Entities.ProductAggregate;

namespace FT.Queries.Productor.Get
{
    public class GetFridgeProductQueryHendler : MediatR.IRequestHandler<GetFridgeProductQuery, IEnumerable<Product>>
    {
        private IUnitOfWork unit;
        private IProductRepository productRepository;

        public GetFridgeProductQueryHendler(IUnitOfWork unit, IProductRepository productRepository)
        {
            this.unit = unit;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetFridgeProductQuery request, CancellationToken cancellationToken)
        {           

            var result = await productRepository.GetAsync(f => f.Fridge.Id == request.FridgeId, f => f.Fridge);

           
            foreach (var product in result)
            {
                product.Fridge.Products = null;
            }
            return result;
        }
    }
}

