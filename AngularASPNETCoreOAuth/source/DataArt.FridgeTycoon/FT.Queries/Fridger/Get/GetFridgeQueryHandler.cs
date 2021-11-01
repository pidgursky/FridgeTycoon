using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Persistence;
using FT.Queries.Exceptions;

namespace FT.Queries.Fridger.Get
{
    
    public class GetFridgeQueryHandler : MediatR.IRequestHandler<GetFridgeQuery, FridgeViewModel>
    {
        private IUnitOfWork unit;
        private IFridgeRepository fridgeRepository;

        public GetFridgeQueryHandler(IUnitOfWork unit, IFridgeRepository fridgeRepository)
        {
            this.unit = unit;
            this.fridgeRepository = fridgeRepository;
        }

        public async Task<FridgeViewModel> Handle(GetFridgeQuery request, CancellationToken cancellationToken)
        {
            var result = await fridgeRepository.GetAsync(f => f.Id == request.Id);

            var fridge = result
                .Select(r => FridgeViewModel.Projection.Compile().Invoke(r))
                .SingleOrDefault();

            if (fridge == null)
            {
                throw new NotFoundException(nameof(Fridge), request.Id);
            }

            return fridge;
        }
    }
}
