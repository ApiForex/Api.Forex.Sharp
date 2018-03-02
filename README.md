# Api.Forex.Sharp
Api.Forex.Sharp

[![NuGet](https://img.shields.io/nuget/v/Api.Forex.Currency.Converter.svg)](https://www.nuget.org/packages/Api.Forex.Currency.Converter)

Open a free account on https://api.forex and get an **api key**

    string ApiForexKey = "{YourKey}"
    DailyRates ForexRates = await ApiForex.GetRate(ApiForexKey);

Convert the rates to an other currency.
Example: convert 5 Thai bahts in Euros

    decimal test = ForexRates.Convert("THB", "EUR", 5)
