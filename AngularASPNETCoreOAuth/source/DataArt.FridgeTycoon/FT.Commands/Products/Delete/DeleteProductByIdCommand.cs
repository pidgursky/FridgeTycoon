using MediatR;
using System;

namespace FT.Commands.Products.Delete
{
    public class DeleteProductByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        
    }
}
