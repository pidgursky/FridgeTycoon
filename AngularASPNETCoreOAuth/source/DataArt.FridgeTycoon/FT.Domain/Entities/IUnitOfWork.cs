using System.Threading.Tasks;

namespace FT.Domain.Entities
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();

    }
}
