using condofy_challenge_API.Domain.Models.Request;
using condofy_challenge_API.Domain.Models.Response;
using condofy_challenge_API.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace condofy_challenge_API.App.Interfaces
{
    public interface IFuncionarioApp
    {
        Task<ObjectReturn> InsertFuncionario(FuncionarioRequest funcionarioRequest);
        Task<IEnumerable<FuncionarioResponse>> GetFuncionario(string startname, List<string> gender, List<string> level, decimal minsalary, decimal maxsalary);
    }
}
