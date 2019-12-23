using condofy_challenge_API.Domain.Entities;
using condofy_challenge_API.Domain.Interfaces.Services;
using condofy_challenge_API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using condofy_challenge_API.Domain.Interfaces.Repositories;
using condofy_challenge_API.Domain.Models.Response;
using System.Threading.Tasks;

namespace condofy_challenge_API.Test.Domain
{
    public class FuncionarioServicesTest
    {
        [Theory(DisplayName = "FillFuncionarioWithInvalidString")]
        [InlineData("1,teste,aa,")]
        [InlineData("wweteasdalmfasdçnadnf")]
        [InlineData(null)]
        public void FillFuncionarioWithInvalidString(string line)
        {
            var _mockInsert = new Mock<IFuncionarioRepository>();
            var _target = new FuncionarioService(_mockInsert.Object);

            _target.FillFuncionariosByCsvLine(line);

            Assert.Equal(1, _target.Notifications.Count);

        }

        [Fact]
        public async Task InsertFuncionarioAlReadyExists()
        {
            var _mockInsert = new Mock<IFuncionarioRepository>();

            var funcionario_response = new FuncionarioResponse()
            {
                Id = "1"
            };

            _mockInsert.Setup(p => p.GetByID(1)).Returns(Task.FromResult(funcionario_response));

            var _target = new FuncionarioService(_mockInsert.Object);

            var new_funcionario = new FuncionarioEntity(1, "wellyngton", new DateTime(1992, 4, 7), 10000, "M", new DateTime(2019, 12, 23), "S");

            await _target.InsertFuncionario(new_funcionario);

            Assert.NotEqual(0, new_funcionario.Notifications.Count);

        }
    }
}
