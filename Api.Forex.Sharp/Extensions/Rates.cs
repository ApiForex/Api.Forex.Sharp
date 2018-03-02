using Api.Forex.Sharp.Models;
using System.Linq;

namespace Api.Forex.Sharp
{
    public static class ConvertExtension
    {
        public static decimal Convert(this ApiForexRates DailyRates, string from, string to, decimal ammount = 1)
        {
            decimal rateFrom = DailyRates.rates.Where(r => r.Key == from).Select(r => r.Value).First();
            decimal rateTo = DailyRates.rates.Where(r => r.Key == to).Select(r => r.Value).First();
            return (rateFrom / rateTo * ammount);
        }
    }
}
