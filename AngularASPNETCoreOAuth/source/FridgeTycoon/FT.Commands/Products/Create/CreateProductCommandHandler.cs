using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FT.Persistence;
using ProductItem = FT.Domain.Entities.ProductAggregate.Product;
using System;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.ProductAggregate;

namespace FT.Commands.Products.Create
{
    public class CreateObjectItemCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {

        private IUnitOfWork _unit;
        private IFridgeRepository _fridgeRepository;
        private IProductRepository _productRepository;

        public CreateObjectItemCommandHandler(IUnitOfWork unit, IFridgeRepository fridgeRepository, IProductRepository productRepository)
        {
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
            _fridgeRepository = fridgeRepository ?? throw new ArgumentNullException(nameof(fridgeRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));


        }



        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var objectItem = new ProductItem
            {
                Name = request.Name
            };
            objectItem.Fridge = await _fridgeRepository.FindByIdAsync(request.FridgeId);

            await _productRepository.CreateAsync(objectItem);
            try
            {
                await _unit.SaveAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objectItem.Id;
        }
    }
}
