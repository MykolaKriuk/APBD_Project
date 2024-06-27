
using APBD_Projekt.DTOs.IncomeDTOs;

namespace APBD_Projekt.Services.IncomeServices;

public interface IIncomeService
{
    public Task<string> GetCurrentIncome
        (string targetCurrency, IncomeRequestModel requestModel, CancellationToken cancellationToken);
    public Task<string> GetPlannedIncome
        (string targetCurrency, IncomeRequestModel requestModel, CancellationToken cancellationToken);
    
}