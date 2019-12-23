using condofy_challenge_API.Shared.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace condofy_challenge_API.Test.Shared
{
    public class DapperFuncitionsTest
    {
        [Theory(DisplayName = "FillLikeOperatorWithInvalidSymbols")]
        [InlineData("*")]
        [InlineData("/")]
        [InlineData(@"\")]
        [InlineData("-")]
        [InlineData("+")]
        [InlineData(".")]
        [InlineData("#")]
        [InlineData("@")]
        [InlineData("$")]
        [InlineData("&")]
        [InlineData("(")]
        [InlineData(")")]
        [InlineData("!")]
        [InlineData("?")]
        [InlineData("%")]
        public void FillLikeOperatorWithInvalidSymbols(string operators)
        {
            var result = DapperFuncitions.FillLikeOperator(operators);
            result = result.Substring(1, result.Length - 1);
            result = result.Substring(0, result.Length - 1);
            var field = Regex.IsMatch(result, @"^[a-zA-Z0-9 ]+$") || result.Trim() == "";
            Assert.True(field);
        }

        [Fact]
        public void FillLikeOperatorWithNullValue()
        {
            var result = DapperFuncitions.FillLikeOperator(null);
            result = result.Substring(1, result.Length - 1);
            result = result.Substring(0, result.Length - 1);
            Assert.Equal("", result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ExistsWhereWithNullorEmptyValue(string sql)
        {
            var ret = DapperFuncitions.ExistsWhere(sql);

            Assert.NotNull(ret);
        }

        [Fact]
        public void ExistsWhereWithOutValidInputSql()
        {
            string sql = "select any text no sql";

            var ret = DapperFuncitions.ExistsWhere(sql);

            Assert.Equal("", ret);
        }
    }
}
