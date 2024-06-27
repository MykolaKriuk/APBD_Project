using APBD_Projekt.Contexts;
using APBD_Projekt.DTOs.FirmsDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Projekt.Services.FirmServices;

public class FirmService(IncManagerContext context) : IFirmService
{
    public async Task AddNewFirmAsync(AddFirmRequestModel clientRequestModel, CancellationToken cancellationToken)
    {
        var checkExistingClients = await context.Firms
            .Where(f => f.FirmKRSNum == clientRequestModel.KRS)
            .FirstOrDefaultAsync(cancellationToken);
        if (checkExistingClients is not null)
        {
            throw new ExistingClientException($"Client of KRS - {clientRequestModel.KRS}, already exists.");
        }

        var newClient = new Client
        {
            ClientAddress = clientRequestModel.Address,
            ClientEmail = clientRequestModel.Email,
            ClientTelNumber = clientRequestModel.TelNum,
            IsPrivateClient = false
        };
        await context.Clients.AddAsync(newClient, cancellationToken);

        var newFirm = new Firm
        {
            Client = newClient,
            FirmName = clientRequestModel.Name,
            FirmKRSNum = clientRequestModel.KRS
        };

        await context.Firms.AddAsync(newFirm, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdatePrivateClientAsync(int clientId, UpdateFirmRequestModel clientRequestModel,
        CancellationToken cancellationToken)
    {
        var existingClient = await context.Firms
            .Include(f => f.Client)
            .Where(f => f.FirmId == clientId)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingClient is null)
        {
            throw new ClientNotFoundException($"Client of id - {clientId}, does not exist");
        }

        existingClient.Client.ClientAddress = clientRequestModel.Address;
        existingClient.Client.ClientEmail = clientRequestModel.Email;
        existingClient.Client.ClientTelNumber = clientRequestModel.TelNum;
        existingClient.FirmName = clientRequestModel.Name;

        await context.SaveChangesAsync(cancellationToken);
    }
}