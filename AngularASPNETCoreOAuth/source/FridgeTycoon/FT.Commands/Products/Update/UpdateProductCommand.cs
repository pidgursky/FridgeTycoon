using MediatR;
using System;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.ProductAggregate;

namespace FT.Commands.Products.Update
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Fridge Fridge { get; set; }
        public RefrigeratorStatus Refrigeratory { get; set; }

        
    }


}
