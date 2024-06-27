using APBD_Projekt.Contexts;
using APBD_Projekt.DTOs.ContractsDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Projekt.Services.ContractServices;

public class ContractService(IncManagerContext context) : IContractService
{
    public async Task CreateContractAsync(AddContractRequestModel requestModel, 
        CancellationToken cancellationToken)
    {
        var existingClient = await context.Clients
            .FirstOrDefaultAsync(c => c.ClientId == requestModel.ClientId, cancellationToken);
        if (existingClient is null)
        {
            throw new ClientNotFoundException
                ($"Client with id {requestModel.ClientId} does not exist");
        }

        var existingSoftVersion = await context.SoftwareVersions
            .FirstOrDefaultAsync(sv => sv.VersionId == requestModel.VersionId, cancellationToken);
        if (existingSoftVersion is null)
        {
            throw new VersionNotFoundException($"Software version with id {requestModel.VersionId} does not exist");
        }

        var checkExistingContract = await context.Contracts
            .FirstOrDefaultAsync(c =>
                    (c.ClientId == existingClient.ClientId &&
                     c.SoftwareVersionId == existingSoftVersion.SoftwareId &&
                     c.ContractDateTo > DateTime.Now),
                cancellationToken
            );
        if (checkExistingContract is not null)
        {
            throw new ExistingContractException(
                $"The client {existingClient.ClientId} already has contract on version {existingSoftVersion.SoftwareId}");
        }

        var timeBetweenDates = requestModel.DateTo - requestModel.DateFrom;
        if (timeBetweenDates.TotalDays is < 3 or > 30)
        {
            throw new DaysOutOfBoundsException($"Time of usage of the software should be between 3 and 30 days");
        }

        if (requestModel.Actualisation is < 1 or > 3)
        {
            throw new InvalidActualisationException("Actualisation number should be between 1 and 3");
        }

        var biggestDiscountValue = await context.SoftwareDiscounts
            .Where(sd => sd.SoftwareId == existingSoftVersion.SoftwareId)
            .OrderByDescending(sd => sd.DiscountValue)
            .Select(sd => sd.DiscountValue)
            .FirstOrDefaultAsync(cancellationToken);

        var newPrice = 
            existingSoftVersion.VersionPrice - 
            existingSoftVersion.VersionPrice * biggestDiscountValue / 100 + 
            1000 * (requestModel.Actualisation ?? 0);
        

        var checkClientPreviousContracts = await context.Contracts
            .FirstOrDefaultAsync(c => c.ClientId == existingClient.ClientId && c.IsSigned, cancellationToken);
        if (checkClientPreviousContracts is not null)
        {
            newPrice -= existingSoftVersion.VersionPrice * (decimal)0.05;
        }

        var newContract = new Contract
        {
            Client = existingClient,
            ContractPrice = newPrice,
            ContractDateFrom = requestModel.DateFrom,
            ContractDateTo = requestModel.DateTo,
            ContractActualisation = requestModel.Actualisation,
            SoftwareVersion = existingSoftVersion,
            IsSigned = false
        };

        await context.Contracts.AddAsync(newContract, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteContractAsync(int contractId, CancellationToken cancellationToken)
    {
        var existingContract = await context.Contracts
            .Include(c => c.Payments)
            .FirstOrDefaultAsync(c => c.ContractId == contractId, cancellationToken);
        if (existingContract is null)
        {
            throw new ContractNotFoundException($"Contract of id {contractId} does not exist");
        }

        context.RemoveRange(existingContract.Payments);
        context.Remove(existingContract);

        await context.SaveChangesAsync(cancellationToken);
    }
}