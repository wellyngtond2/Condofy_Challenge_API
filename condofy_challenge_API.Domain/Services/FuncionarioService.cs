using condofy_challenge_API.Domain.Entities;
using condofy_challenge_API.Domain.Interfaces.Repositories;
using condofy_challenge_API.Domain.Interfaces.Services;
using condofy_challenge_API.Shared.Functions;
using prmToolkit.NotificationPattern;
using System;
using System.Threading.Tasks;

namespace condofy_challenge_API.Domain.Services
{
    public class FuncionarioService : Notifiable, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public FuncionarioEntity FillFuncionariosByCsvLine(string line)
        {
            if(string.IsNullOrEmpty(line) || !line.Contains(";"))
            {
                AddNotification("FillFuncionario", "Invalid input Data!");
                return null;
            }

            string[] funcionariosData = line.Split(';');

            return new FuncionarioEntity(funcionariosData[0].IsValid().ToInt(),
                                                     funcionariosData[1].IsValid(),
                                                     funcionariosData[2].IsValid().ToDate(),
                                                     funcionariosData[3].IsValid().ToDecimal(),
                                                     funcionariosData[4].IsValid(),
                                                     funcionariosData[5].IsValid().ToDate(),
                                                     funcionariosData[6].IsValid());
        }

        public async Task<bool> InsertFuncionario(FuncionarioEntity funcionario)
        {
            try
            {
                if (await _funcionarioRepository.GetByID(funcionario.Id) != null)
                {
                    funcionario.AddNotification("funcionario", string.Format("The funcionario {0} with id {1} already exist", funcionario.Name, funcionario.Id));
                    return await Task.FromResult(false);
                }

                await _funcionarioRepository.Insert(funcionario);

                return await Task.FromResult(true);

            }
            catch (Exception ex)
            {
                funcionario.AddNotification("Insert funcionario", ex.Message);
                return await Task.FromResult(false);
            }
        }
    }
}
