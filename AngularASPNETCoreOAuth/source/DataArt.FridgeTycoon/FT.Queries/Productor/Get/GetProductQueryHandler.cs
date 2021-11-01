using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FT.Domain.Entities;
using FT.Domain.Entities.ProductAggregate;
using FT.Persistence;
using FT.Queries.Exceptions;

namespace FT.Queries.Productor.Get
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private IUnitOfWork unit;
        private IProductRepository productRepository;

        public GetProductQueryHandler(IUnitOfWork unit, IProductRepository productRepository)
        {
            this.unit = unit;
            this.productRepository = productRepository;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await productRepository.GetAsync(p => p.Id == request.Id);

            var product = result
                .Select(r => ProductViewModel.Projection.Compile().Invoke(r))
                .SingleOrDefault();
            
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return product;
        }
    }
}
