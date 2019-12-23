using condofy_challenge_API.Domain.Interfaces.Config;
using Microsoft.Extensions.Configuration;

namespace condofy_challenge_API.Infra.Config
{
    public class DBConfig : IDBConfig
    {
        private readonly IConfiguration _configuration;
        public DBConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("CondofyConnection").Value;
        }
    }
}
