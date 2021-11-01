using MediatR;
using System;
using FT.Domain.Entities;
using FT.Persistence;
using System.Threading.Tasks;
using System.Threading;
using FT.Domain.Entities.ProductAggregate;

namespace FT.Commands.Products.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private IUnitOfWork _unit;
        private IProductRepository _productRepository;

        public UpdateProductCommandHandler(IUnitOfWork unit, IProductRepository productRepository)
        {
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        }
        public async Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindByIdAsync(command.Id);

            if (product == null)
            {
                throw new Exception("Сould not be emty.");

            }

            else
            {
                product.Name = command.Name;
                product.Refrigeratory = command.Refrigeratory;
                product.Fridge = command.Fridge;
                _productRepository.Update(product);
                await _unit.SaveAsync();
                return product;
            }
        }
    }
}
