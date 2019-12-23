using condofy_challenge_API.Shared.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace condofy_challenge_API.Test.Shared
{
    public class ByteFunctionsTest
    {
        [Fact(DisplayName = "ConvertStreamToByteWithNullValue")]
        public void ConvertStreamToByteWithNullValue()
        {
            var result = ByteFunctions.ConverteStreamToByteArray(null);

            Assert.NotNull(result);
        }
    }
}
