using FT.Domain.Entities.Users;

namespace FT.Persistence
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FTDBContext context) : base(context)
        {
        }               
    
    }
    
}
