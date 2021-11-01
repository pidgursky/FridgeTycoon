using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.Users;
using FT.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FT.Queries.Fridger.Get
{
    public class GetAllFridgesQuery : IRequest<IEnumerable<Fridge>>
    {
        public class GetAllFridgeQueryHandler : IRequestHandler<GetAllFridgesQuery, IEnumerable<Fridge>>
        {
            private IUnitOfWork unit;
            private IFridgeRepository fridgeRepository;

            public GetAllFridgeQueryHandler(IUnitOfWork unit, IFridgeRepository fridgeRepository)
            {
                this.unit = unit;
                this.fridgeRepository = fridgeRepository;
            }

            public async Task<IEnumerable<Fridge>> Handle(GetAllFridgesQuery query, CancellationToken cancellationToken)
            {
                var fridgeList = await fridgeRepository.GetAsync();
                return fridgeList;
            }
        }
    }
}
