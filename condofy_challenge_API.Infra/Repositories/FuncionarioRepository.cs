using condofy_challenge_API.Domain.Entities;
using condofy_challenge_API.Domain.Interfaces.Config;
using condofy_challenge_API.Domain.Interfaces.Repositories;
using condofy_challenge_API.Domain.Models.Response;
using condofy_challenge_API.Shared.Functions;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace condofy_challenge_API.Infra.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IDBConfig _DBConfig;

        public FuncionarioRepository(IDBConfig DBConfig)
        {
            _DBConfig = DBConfig;
        }

        public async Task<FuncionarioResponse> GetByID(int id)
        {
            string sql = "select * from funcionarios where id = @id";
            using (var connection = new SqlConnection(_DBConfig.GetConnectionString()))
            {
                return await connection.QueryFirstOrDefaultAsync<FuncionarioResponse>(sql, new { id });
            }
        }

        public async Task<IEnumerable<FuncionarioResponse>> GetFuncionario(string startname, List<string> gender, List<string> level, decimal? minsalary, decimal? maxsalary)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from funcionarios ");

            if (!string.IsNullOrEmpty(startname))
                sql.AppendLine(string.Format(" {0} name like @startname", DapperFuncitions.ExistsWhere(sql.ToString())));
            if (gender.Count > 0)
                sql.AppendLine(string.Format(" {0} gender in @gender", DapperFuncitions.ExistsWhere(sql.ToString())));
            if (level.Count > 0)
                sql.AppendLine(string.Format(" {0} level in @level", DapperFuncitions.ExistsWhere(sql.ToString())));
            if ((minsalary ?? 0m) > 0)
                sql.AppendLine(string.Format(" {0} salary < @minsalary", DapperFuncitions.ExistsWhere(sql.ToString())));
            if ((maxsalary ?? 0m) > 0)
                sql.AppendLine(string.Format(" {0} salary > @maxsalary", DapperFuncitions.ExistsWhere(sql.ToString())));

            using (var connection = new SqlConnection(_DBConfig.GetConnectionString()))
            {
                return await connection.QueryAsync<FuncionarioResponse>(sql.ToString(), new { startname = startname.FillLikeOperator(), gender, level, minsalary, maxsalary });
            }
        }

        public async Task Insert(FuncionarioEntity data)
        {
            string sql = @"insert into funcionarios (Id,Name,Gender, BirthDay,Salary,HiringDate,Level)
                                             values (@Id,@Name,@Gender, @BirthDay,@Salary,@HiringDate,@Level)";

            using (var connection = new SqlConnection(_DBConfig.GetConnectionString()))
            {
                await connection.QueryFirstOrDefaultAsync(sql, data);
            }
        }
    }
}
