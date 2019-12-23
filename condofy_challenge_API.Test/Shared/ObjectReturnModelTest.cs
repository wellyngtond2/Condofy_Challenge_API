using condofy_challenge_API.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace condofy_challenge_API.Test.Shared
{
 public   class ObjectReturnModelTest
    {

        [Fact]
        public void InsertNullorEmptyMessage()
        {
            var _objReturn = new ObjectReturn(1, "");
            _objReturn.AddMessage(null);

            Assert.DoesNotContain(null, _objReturn.Messagens);
        }
    }
}
