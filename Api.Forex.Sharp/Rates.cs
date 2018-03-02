using Api.Forex.Sharp.Models;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Forex.Sharp
{
    public class ApiForex
    {
        private const string BaseUri = "http://v1.api.forex/";
        public static async Task<ApiForexRates> GetRate(string key = null, string format = "proto", string from = "USD", string[] to = null, DateTime? date = null)
        {
            string CurrencyToConvert = string.Empty;
            if (to != null)
            {
                CurrencyToConvert = string.Join(",", to);
            }
            ApiForexRates ApiForexRates = new ApiForexRates();
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(BaseUri + "daily-rates." + format + "?from=" + from + "&to=" + CurrencyToConvert + "&key=" + key))
            using (HttpContent content = response.Content)
                switch (format)
                {
                    case "proto":
                        using (var memoryStream = new MemoryStream())
                        {
                            await content.CopyToAsync(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            ApiForexRates = Serializer.Deserialize<ApiForexRates>(memoryStream);
                        }
                        break;
                    case "json":
                        ApiForexRates = JsonConvert.DeserializeObject<ApiForexRates>(await content.ReadAsStringAsync());
                        break;
                }
            return ApiForexRates;
        }
        public static async Task<string> GetRateJson(string key = null, string from = "USD", string[] to = null, DateTime? date = null)
        {
            string CurrencyToConvert = string.Empty;
            if (to != null)
            {
                CurrencyToConvert = string.Join(",", to);
            }
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(BaseUri + "daily-rates.json?from=" + from + "&to=" + CurrencyToConvert + "&key=" + key))
            using (HttpContent content = response.Content)
                return await content.ReadAsStringAsync();
        }
        public static async Task<Dictionary<string, CurrencyInfos>> GetCurrenciesInfos(string lang = "en", string[] currencies = null, string format = "json")
        {
            string CurrenciesInfos = string.Empty;
            if (currencies != null)
            {
                CurrenciesInfos = string.Join(",", currencies);
            }
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(BaseUri + "infos." + format + "?lang=" + lang + "&currencies=" + CurrenciesInfos))
            using (HttpContent content = response.Content)
                switch (format)
                {
                    case "proto":
                        using (var memoryStream = new MemoryStream())
                        {
                            await content.CopyToAsync(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            return Serializer.Deserialize<Dictionary<string, CurrencyInfos>>(memoryStream);
                        }
                    case "json":
                        return JsonConvert.DeserializeObject<Dictionary<string, CurrencyInfos>>(await content.ReadAsStringAsync());
                }
            return new Dictionary<string, CurrencyInfos>();
        }
    }
}



