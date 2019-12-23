using condofy_challenge_API.Domain.Entities;
using System.Threading.Tasks;

namespace condofy_challenge_API.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        Task<bool> InsertFuncionario(FuncionarioEntity funcionario);
        FuncionarioEntity FillFuncionariosByCsvLine(string line);
    }
}
