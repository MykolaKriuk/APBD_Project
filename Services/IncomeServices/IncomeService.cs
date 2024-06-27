using APBD_Projekt.Contexts;
using APBD_Projekt.DTOs.IncomeDTOs;
using APBD_Projekt.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD_Projekt.Services.IncomeServices;

public class IncomeService : IIncomeService
{
    private readonly IncManagerContext _context;
    private readonly CurrencyService exchangeRateService;

    public IncomeService(IncManagerContext context, CurrencyService exchangeRateService)
    {
        this._context = context;
        this.exchangeRateService = exchangeRateService;
    }

    public async Task<string> GetCurrentIncome(string targetCurrency, IncomeRequestModel requestModel, CancellationToken cancellationToken)
    {
        decimal income;
        if (requestModel.SoftwareId is null)
        {
            income = await _context.Contracts
                .Where(c => c.IsSigned)
                .SumAsync(c => c.ContractPrice, cancellationToken);
        }
        else
        {
            var existingSoftware = await _context.SoftwareSystems
                .FirstOrDefaultAsync(ss => ss.SoftwareId == requestModel.SoftwareId, cancellationToken);
            if (existingSoftware is null)
            {
                throw new SoftwareNotFoundException($"Software with id {requestModel.SoftwareId} does not exist");
            }
            income = await _context.Contracts
                .Include(c => c.SoftwareVersion)
                .ThenInclude(sv => sv.SoftwareSystem)
                .Where(c => c.IsSigned &&
                            c.SoftwareVersion.SoftwareSystem.SoftwareId == requestModel.SoftwareId)
                .SumAsync(c => c.ContractPrice, cancellationToken);
        }

        var exchangeRate = await exchangeRateService.GetExchangeRateAsync(targetCurrency);
        return $"Current income is {Math.Round(income / exchangeRate, 2)} {targetCurrency}";
    }
    
    public async Task<string> GetPlannedIncome(string targetCurrency, IncomeRequestModel requestModel, CancellationToken cancellationToken)
    {
        decimal income;
        if (requestModel.SoftwareId is null)
        {
            income = await _context.Contracts
                .SumAsync(c => c.ContractPrice, cancellationToken);
        }
        else
        {
            var existingSoftware = await _context.SoftwareSystems
                .FirstOrDefaultAsync(ss => ss.SoftwareId == requestModel.SoftwareId, cancellationToken);
            if (existingSoftware is null)
            {
                throw new SoftwareNotFoundException($"Software with id {requestModel.SoftwareId} does not exist");
            }
            income = await _context.Contracts
                .Include(c => c.SoftwareVersion)
                .ThenInclude(sv => sv.SoftwareSystem)
                .Where(c => c.SoftwareVersion.SoftwareSystem.SoftwareId == requestModel.SoftwareId)
                .SumAsync(c => c.ContractPrice, cancellationToken);
        }

        var exchangeRate = await exchangeRateService.GetExchangeRateAsync(targetCurrency);
        return $"Planned income is {Math.Round(income / exchangeRate, 2)} {targetCurrency}";
    }
}
