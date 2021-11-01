using MediatR;
using System;
using FT.Persistence;
using System.Threading.Tasks;
using System.Threading;
using FT.Domain.Entities;
using FT.Domain.Entities.ProductAggregate;

namespace FT.Commands.Products.Delete
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Guid>
    {
        private IUnitOfWork _unit;
        private IProductRepository _productRepository;

        public DeleteProductByIdCommandHandler(IUnitOfWork unit, IProductRepository productRepository)
        {
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        }
        public async Task<Guid> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {

            var product = await _productRepository.FindByIdAsync(command.Id);
            _productRepository.Remove(product);
            await _unit.SaveAsync();
            return product.Id;

        }
    }
}
