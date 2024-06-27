using Newtonsoft.Json;

namespace APBD_Projekt.Services.IncomeServices;

public class CurrencyService(HttpClient httpClient)
{
    public async Task<decimal> GetExchangeRateAsync(string targetCurrency)
    {
        var response =
            await httpClient.GetStringAsync($"https://api.nbp.pl/api/exchangerates/rates/A/{targetCurrency}/?format=json");
        var exchangeData = JsonConvert.DeserializeObject<ExchangeRateResponse>(response);
        return exchangeData.Rates.First().Mid;
    }
}