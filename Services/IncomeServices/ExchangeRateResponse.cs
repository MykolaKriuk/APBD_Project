namespace APBD_Projekt.Services.IncomeServices;

public class ExchangeRateResponse
{
    public string Table { get; set; }
    public string Currency { get; set; }
    public string Code { get; set; }
    public List<Rate> Rates { get; set; }
}