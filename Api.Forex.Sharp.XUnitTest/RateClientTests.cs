using System.Linq;
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
        [Fact]
        public void CurrenciesInfos()
        {
            var CurrenciesInfos = ApiForex.GetCurrenciesInfos("fr", new string[] { "EUR", "THB"}, "json").Result.Where(c=>c.Key == "THB").FirstOrDefault().Value.Code;
            Assert.Equal("THB", CurrenciesInfos);
        }
    }
}
