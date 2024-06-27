using APBD_Projekt.DTOs.ContractsDTOs;

namespace APBD_Projekt.Services.ContractServices;

public interface IContractService
{
    public Task CreateContractAsync(AddContractRequestModel requestModel, 
        CancellationToken cancellationToken);

    public Task DeleteContractAsync(int contractId, CancellationToken cancellationToken);
}