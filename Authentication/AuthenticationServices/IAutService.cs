using APBD_Projekt.Authentication.AuthenticationDTOs;

namespace APBD_Projekt.Authentication.AuthenticationServices;

public interface IAutService
{
    public Task RegisterNewWorkerAsync(RegisterWorkerRequestModel requestModel, CancellationToken cancellationToken);
    public Task<string> LoginWorkerAsync(LoginWorkerRequestModel requestModel, CancellationToken cancellationToken);
}