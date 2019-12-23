using condofy_challenge_API.Domain.Entities;
using System;
using Xunit;

namespace condofy_challenge_API.Test.Entity
{
    public class FuncionarioEntityTest
    {
        [Theory(DisplayName = "CreateFuncionarioWithZeroOrNegativeID")]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-555)]
        [InlineData(0)]
        public void CreateFuncionarioWithZeroOrNegativeID(int id)
        {
            var funcionario = new FuncionarioEntity(id, "Wellyngton", DateTime.Now, 1000, "M", DateTime.Now, "S");

            Assert.Equal(1, funcionario.Notifications.Count);
        }

        [Fact(DisplayName = "CreateFuncionarioWithNameLengthThan64")]
        public void CreateFuncionarioWithNameLengthThan64()
        {
            var funcionario = new FuncionarioEntity(1, "WellyngtonWellyngtonWellyngtonWellyngtonWellyngtonWellyngtonWellyngton", DateTime.Now, 1000, "M", DateTime.Now, "S");

            Assert.Equal(1, funcionario.Notifications.Count);
        }

        [Theory(DisplayName = "CreateFuncionarioWithGenderDifferentFrom_M_and_F")]
        [InlineData("A")]
        [InlineData("B")]
        [InlineData("-")]
        [InlineData("1")]
        public void CreateFuncionarioWithGenderDifferentFrom_M_and_F(string gender)
        {
            var funcionario = new FuncionarioEntity(1, "Wellyngton", DateTime.Now, 1000, gender, DateTime.Now, "S");

            Assert.Equal(1, funcionario.Notifications.Count);
        }

        [Theory(DisplayName = "CreateFuncionarioWithLevelDifferentFrom_J_P_S")]
        [InlineData("A")]
        [InlineData("B")]
        [InlineData("-")]
        [InlineData("1")]
        public void CreateFuncionarioWithLevelDifferentFrom_J_P_S(string level)
        {
            var funcionario = new FuncionarioEntity(1, "Wellyngton", DateTime.Now, 1000, "M", DateTime.Now, level);

            Assert.Equal(1, funcionario.Notifications.Count);
        }

        [Fact(DisplayName = "CreateFuncionarioWithBirthDayLargerThanToday")]
        public void CreateFuncionarioWithBirthDayLargerThanToday()
        {
            var funcionario = new FuncionarioEntity(1, "Wellyngton", DateTime.Now.AddDays(1), 1000, "M", DateTime.Now, "S");

            Assert.Equal(1, funcionario.Notifications.Count);
        }

        [Fact(DisplayName = "CreateFuncionarioWithHiringDateLargerThanToday")]
        public void CreateFuncionarioWithHiringDateLargerThanToday()
        {
            var funcionario = new FuncionarioEntity(1, "Wellyngton", DateTime.Now, 1000, "M", DateTime.Now.AddDays(1), "S");

            Assert.Equal(1, funcionario.Notifications.Count);
        }

        [Theory(DisplayName = "CreateFuncionarioWithHiringDateLargerThanToday")]
        [InlineData(700)]
        [InlineData(800)]
        public void CreateFuncionarioWithSalaryLowerThan800(decimal salary)
        {
            var funcionario = new FuncionarioEntity(1, "Wellyngton", DateTime.Now, salary, "M", DateTime.Now, "S");

            Assert.Equal(1, funcionario.Notifications.Count);
        }
    }
}