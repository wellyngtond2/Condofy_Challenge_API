using condofy_challenge_API.Domain.Models.Base;

namespace condofy_challenge_API.Domain.Models.Response
{
    public class FuncionarioResponse : ModelsBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDay { get; set; }
        public string Salary { get; set; }
        public string HiringDate { get; set; }
        public string Level { get; set; }
    }
}
