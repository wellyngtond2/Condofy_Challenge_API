using condofy_challenge_API.Domain.Models.Base;
using Microsoft.AspNetCore.Http;

namespace condofy_challenge_API.Domain.Models.Request
{
    public class FuncionarioRequest : ModelsBase
    {
        public IFormFile InputFile { get; set; }
    }
}
