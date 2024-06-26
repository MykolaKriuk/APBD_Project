using APBD_Projekt.DTOs.FirmsDTOs;

namespace APBD_Projekt.Services.FirmServices;

public interface IFirmService
{
    public Task AddNewFirmAsync
        (AddFirmRequestModel clientRequestModel, CancellationToken cancellationToken);
    public Task UpdatePrivateClientAsync
        (int clientId, UpdateFirmRequestModel clientRequestModel, CancellationToken cancellationToken);
}