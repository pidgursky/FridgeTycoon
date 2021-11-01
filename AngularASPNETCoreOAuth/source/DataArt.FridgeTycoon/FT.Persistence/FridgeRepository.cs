using FT.Domain.Entities.FridgeAggregate;

namespace FT.Persistence
{
    public class FridgeRepository : BaseRepository<Fridge>, IFridgeRepository
    {
        public FridgeRepository(FTDBContext context) : base(context)
        {
        }

    }
}
