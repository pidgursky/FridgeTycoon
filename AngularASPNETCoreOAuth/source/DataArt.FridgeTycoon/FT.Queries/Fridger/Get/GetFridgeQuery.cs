using MediatR;
using System;

namespace FT.Queries.Fridger.Get
{
    public class GetFridgeQuery : IRequest<FridgeViewModel>
    {
        public Guid Id { get; set; }
        
    }
}
