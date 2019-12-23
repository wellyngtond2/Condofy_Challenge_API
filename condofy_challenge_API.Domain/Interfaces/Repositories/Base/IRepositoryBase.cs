using System.Threading.Tasks;

namespace condofy_challenge_API.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T>
    {
        Task<T> GetByID(int id);
    }
}
