using condofy_challenge_API.Shared.Functions;
using System;
using Xunit;

namespace condofy_challenge_API.Test.Shared
{
    public class StringFunctionsTest
    {
        [Fact(DisplayName = "ConvertToIntWithNullValue")]
        public void ConvertToIntWithNullValue()
        {
            var result = StringFunctions.ToInt(null);

            Assert.NotNull(result);
        }

        [Theory(DisplayName = "ConvertToIntWithOutNumber")]
        [InlineData("a")]
        [InlineData("*")]
        [InlineData("sda")]
        [InlineData(" ")]
        public void ConvertToIntWithOutNumber(string text)
        {
            var result = StringFunctions.ToInt(text);

            Assert.IsType(typeof(int), result);
        }

        [Fact(DisplayName = "ConvertToDecimalWithNullValue")]
        public void ConvertToDecimalWithNullValue()
        {
            var result = StringFunctions.ToDecimal(null);

            Assert.NotNull(result);
        }

        [Theory(DisplayName = "ConvertToDecimalWithOutNumber")]
        [InlineData("a")]
        [InlineData("*")]
        [InlineData("sda")]
        [InlineData(" ")]
        public void ConvertToDecimalWithOutNumber(string text)
        {
            var result = StringFunctions.ToDecimal(text);

            Assert.IsType(typeof(decimal), result);
        }

        [Fact(DisplayName = "ConvertToDateWithNullValue")]
        public void ConvertToDateWithNullValue()
        {
            var result = StringFunctions.ToDate(null);

            Assert.NotNull(result);
        }

        [Theory(DisplayName = "ConvertToDateWithOutDate")]
        [InlineData("a")]
        [InlineData("*")]
        [InlineData("sda")]
        [InlineData(" ")]
        [InlineData("0")]
        [InlineData("155")]
        [InlineData("57,4")]
        public void ConvertToDateWithOutDate(string text)
        {
            var result = StringFunctions.ToDate(text);

            Assert.IsType(typeof(DateTime), result);
        }

        [Theory(DisplayName = "ConvertToDateWithOutHourDate")]
        [InlineData("2019-01-01")]
        [InlineData("01-01-2019")]
        public void ConvertToDateWithOutHourDate(string text)
        {
            var result = StringFunctions.ToDate(text);

            Assert.IsType(typeof(DateTime), result);
        }

        [Fact(DisplayName = "IsValidStringWithNullValue")]
        public void IsValidStringWithNullValue()
        {
            var result = StringFunctions.IsValid(null);

            Assert.NotNull(result);
        }
    }
}
