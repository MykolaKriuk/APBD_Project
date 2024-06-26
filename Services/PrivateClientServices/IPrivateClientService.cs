using APBD_Projekt.DTOs.PrivateClientDTOs;

namespace APBD_Projekt.Services.PrivateClientService;

public interface IPrivateClientService
{
    public Task AddNewPrivateClientAsync
        (AddPrivateClientRequestModel clientRequestModel, CancellationToken cancellationToken);
    public Task UpdatePrivateClientAsync
        (int clientId, UpdatePrivateClientRequestModel clientRequestModel, CancellationToken cancellationToken);
    public Task DeletePrivateClientAsync
        (int clientId, CancellationToken cancellationToken);
}