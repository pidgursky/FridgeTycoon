using MediatR;
using System;

namespace FT.Queries.Productor.Get
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public Guid Id { get; set; }

    }
}
