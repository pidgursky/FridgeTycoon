using FT.Domain.Entities;
using FT.Domain.Entities.ProductAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace FT.Queries.Productor.Get
{
    public class GetFridgeProductQuery : IRequest<IEnumerable<Product>>
    {
        public Guid FridgeId { get; set; }


    }
}
