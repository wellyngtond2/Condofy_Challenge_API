using condofy_challenge_API.Domain.Entities;
using condofy_challenge_API.Domain.Interfaces.Repositories;
using condofy_challenge_API.Domain.Interfaces.Services;
using condofy_challenge_API.Domain.Models.Request;
using condofy_challenge_API.Shared.Functions;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace condofy_challenge_API.Infra.Repositories
{
    public class FileRepository : Notifiable, IFileRepository
    {
        private readonly IFuncionarioService _funcionarioService;

        public FileRepository(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public async Task<List<FuncionarioEntity>> ReadCSVFile(FuncionarioRequest funcionarios)
        {
            string line;
            List<FuncionarioEntity> listOfFuncionarios = new List<FuncionarioEntity>();

            byte[] funcionariofile = await FileStreamToByte(funcionarios);
            RemoveFile(funcionarios);

            using (var ms = new MemoryStream(funcionariofile))
            using (var stream = new StreamReader(ms))
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    var funcionario = _funcionarioService.FillFuncionariosByCsvLine(line);
                    if (funcionario.Notifications.Count == 0)
                        listOfFuncionarios.Add(funcionario);
                }

            return listOfFuncionarios;
        }

        private static async Task<byte[]> FileStreamToByte(FuncionarioRequest funcionarios)
        {
            using (var fileStream = new FileStream(funcionarios.InputFile.FileName, FileMode.Create))
            {
                await funcionarios.InputFile.CopyToAsync(fileStream);
                return await ByteFunctions.ConverteStreamToByteArray(funcionarios.InputFile.OpenReadStream());
            }
        }

        private static void RemoveFile(FuncionarioRequest funcionarios)
        {
            var file_name = funcionarios.InputFile.FileName;
            if ((System.IO.File.Exists(file_name)))
            {
                System.IO.File.Delete(file_name);
            }
        }
    }
}
