using APBD_Projekt.Contexts;
using APBD_Projekt.DTOs.PrivateClientDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Projekt.Services.PrivateClientService;

public class PrivateClientService(IncManagerContext context) : IPrivateClientService
{
    public async Task AddNewPrivateClientAsync
        (AddPrivateClientRequestModel clientRequestModel, CancellationToken cancellationToken)
    {
        var checkExistingClients = await context.PrivateClients
            .Where(pc => pc.ClientPesel == clientRequestModel.Pesel)
            .FirstOrDefaultAsync(cancellationToken);
        if (checkExistingClients is not null)
        {
            throw new ExistingClientException($"Client of Pesel - {clientRequestModel.Pesel}, already exists.");
        }

        var newClient = new Client
        {
            ClientAddress = clientRequestModel.Address,
            ClientEmail = clientRequestModel.Email,
            ClientTelNumber = clientRequestModel.TelNum,
            IsPrivateClient = true
        };
        await context.Clients.AddAsync(newClient, cancellationToken);

        var newPrivateClient = new PrivateClient
        {
            Client = newClient,
            ClientFirstName = clientRequestModel.FirstName,
            ClientLastName = clientRequestModel.LastName,
            ClientPesel = clientRequestModel.Pesel
        };

        await context.PrivateClients.AddAsync(newPrivateClient, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdatePrivateClientAsync
        (int clientId, UpdatePrivateClientRequestModel clientRequestModel, CancellationToken cancellationToken)
    {
        var existingClient = await context.PrivateClients
            .Include(pc => pc.Client)
            .Where(c => c.PrivateClientId == clientId)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingClient is null)
        {
            throw new ClientNotFoundException($"Client of id - {clientId}, does not exist");
        }

        existingClient.ClientFirstName = clientRequestModel.FirstName;
        existingClient.ClientLastName = clientRequestModel.LastName;
        existingClient.Client.ClientAddress = clientRequestModel.Address;
        existingClient.Client.ClientEmail = clientRequestModel.Email;
        existingClient.Client.ClientTelNumber = clientRequestModel.TelNum;

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeletePrivateClientAsync
        (int clientId, CancellationToken cancellationToken)
    {
        var existingClient = await context.PrivateClients
            .Where(c => c.PrivateClientId == clientId)
            .FirstOrDefaultAsync(cancellationToken);
        if (existingClient is null)
        {
            throw new ClientNotFoundException($"Client of id - {clientId}, does not exist");
        }

        existingClient.IsDeleted = true;
        await context.SaveChangesAsync(cancellationToken);
    }
}