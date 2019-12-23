using condofy_challenge_API.Domain.Entities;
using condofy_challenge_API.Domain.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace condofy_challenge_API.Domain.Interfaces.Repositories
{
    public interface IFileRepository
    {
        Task<List<FuncionarioEntity>> ReadCSVFile(FuncionarioRequest funcionarios);
    }
}
