using MediatR;
using System;

namespace FT.Commands.Products.Create
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public Guid FridgeId { get; set; }

        public string Name { get; set; }

        public int Refrigeratory { get; set; }
        
    }
}
