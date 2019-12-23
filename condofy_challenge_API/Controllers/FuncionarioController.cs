using condofy_challenge_API.App.Interfaces;
using condofy_challenge_API.Domain.Models.Request;
using condofy_challenge_API.Domain.Models.Response;
using condofy_challenge_API.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace condofy_challenge_API.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioApp _funcionarioApp;

        public FuncionarioController(IFuncionarioApp funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get(string startname, List<string> gender, List<string> level, decimal minsalary, decimal maxsalary)
        {
            IEnumerable<FuncionarioResponse> funcionarios = await _funcionarioApp.GetFuncionario(startname, gender, level, minsalary, maxsalary);
            return JsonConvert.SerializeObject(funcionarios);
        }

        [HttpPost]
        public async Task<string> UploadFuncionarios([FromForm]FuncionarioRequest objectFile)
        {
            ObjectReturn objectReturn = new ObjectReturn();
            objectReturn = await _funcionarioApp.InsertFuncionario(objectFile);

            return JsonConvert.SerializeObject(objectReturn);
        }


    }
}
