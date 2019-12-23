using condofy_challenge_API.App.Interfaces;
using condofy_challenge_API.Domain.Entities;
using condofy_challenge_API.Domain.Interfaces.Repositories;
using condofy_challenge_API.Domain.Interfaces.Services;
using condofy_challenge_API.Domain.Models.Request;
using condofy_challenge_API.Domain.Models.Response;
using condofy_challenge_API.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace condofy_challenge_API.App.App
{
    public class FuncionarioApp : IFuncionarioApp
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IFileRepository _fileRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioApp(IFuncionarioService funcionarioService, IFileRepository fileRepository, IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioService = funcionarioService;
            _fileRepository = fileRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public Task<IEnumerable<FuncionarioResponse>> GetFuncionario(string startname, List<string> gender, List<string> level, decimal minsalary, decimal maxsalary)
        {
            return _funcionarioRepository.GetFuncionario(startname, gender, level, minsalary, maxsalary);
        }

        public async Task<ObjectReturn> InsertFuncionario(FuncionarioRequest funcionarioRequest)
        {
            ObjectReturn objectReturn = new ObjectReturn();
            List<FuncionarioEntity> funcionarios = await _fileRepository.ReadCSVFile(funcionarioRequest);

            for (int position = 0; position < funcionarios.Count; position++)
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var success = await _funcionarioService.InsertFuncionario(funcionarios[position]);
                    if (funcionarios[position].IsInvalid() || !success)
                    {
                        funcionarios[position].Notifications.ToList().ForEach(p => objectReturn.AddMessage(string.Format("Fail to process register : line: {0}, property: {1}, description: {2}", position + 1, p.Property, p.Message)));
                        continue;
                    }
                    transaction.Complete();
                    objectReturn.AddMessage(string.Format("Line {0} - Funcionario {1}, ID {2} successfully inserted!", position + 1, funcionarios[position].Name, funcionarios[position].Id));

                }
            }
            return await Task.FromResult(objectReturn);
        }
    }
}
