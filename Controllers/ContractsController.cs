using APBD_Projekt.DTOs.ContractsDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Services.ContractServices;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractsController(IContractService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddNewContract(AddContractRequestModel requestModel, CancellationToken cancellationToken)
    {
        try
        {
            await service.CreateContractAsync(requestModel, cancellationToken);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (VersionNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ExistingContractException e)
        {
            return Conflict(e.Message);
        }
        catch (DaysOutOfBoundsException e)
        {
            return Conflict(e.Message);
        }
        catch (InvalidActualisationException e)
        {
            return Conflict(e.Message);
        }

        return Created();
    }

    [HttpDelete("{contractId}")]
    public async Task<IActionResult> DeleteContract(int contractId, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeleteContractAsync(contractId, cancellationToken);
        }
        catch (ContractNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }
}