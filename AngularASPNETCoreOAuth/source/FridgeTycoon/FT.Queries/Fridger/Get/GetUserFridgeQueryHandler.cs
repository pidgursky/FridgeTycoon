using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FT.Domain.Entities;
using FT.Persistence;
using System.Collections.Generic;
using FT.Domain.Entities.FridgeAggregate;
using FT.Services.UserClaimService;
using FT.Domain.Entities.Users;

namespace FT.Queries.Fridger.Get
{
    
    public class GetUserFridgeQueryHandler : MediatR.IRequestHandler<GetUserFridgeQuery,IEnumerable<Fridge>>
    {
        private IUnitOfWork unit;
        private IFridgeRepository fridgeRepository;
        private IUserClaimService userClaimService;

        public GetUserFridgeQueryHandler(IUnitOfWork unit, IFridgeRepository fridgeRepository, IUserClaimService userClaimService)
        {
            this.unit = unit;
            this.fridgeRepository = fridgeRepository;
            this.userClaimService = userClaimService;
        }



        public async Task<IEnumerable<Fridge>> Handle(GetUserFridgeQuery request, CancellationToken cancellationToken)
        {

            var result = await fridgeRepository.GetAsync(f => f.User.Id == userClaimService.UserId, f=>f.User);

            foreach (var fridge in result)
            {
                fridge.User.Fridges = null;
            }
            return result.ToList();
        }
    }
}
