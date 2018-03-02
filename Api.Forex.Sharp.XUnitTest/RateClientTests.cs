using System;
using Xunit;

namespace Api.Forex.Sharp.XUnitTest
{
    public class RateClientTests
    {
        [Fact]
        public void NoKeyProvided()
        {
            var ApiForexRates = ApiForex.GetRate("");
            Assert.NotEqual(200, ApiForexRates.Result.error.code);
        }
    }
}
