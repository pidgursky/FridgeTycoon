using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace FT.Queries.Fridger.Get
{
    public class GetUserFridgeQuery : IRequest<IEnumerable<Fridge>>
    {
    }
}
