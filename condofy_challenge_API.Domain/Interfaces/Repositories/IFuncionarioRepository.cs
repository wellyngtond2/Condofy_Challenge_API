using condofy_challenge_API.Domain.Entities;
using condofy_challenge_API.Domain.Interfaces.Repositories.Base;
using condofy_challenge_API.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace condofy_challenge_API.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IRepositoryBase<FuncionarioResponse>
    {
        Task Insert(FuncionarioEntity data);
        Task<IEnumerable<FuncionarioResponse>> GetFuncionario(string startname, List<string> gender, List<string> level, decimal? minsalary, decimal? maxsalary);
        
    }
}
