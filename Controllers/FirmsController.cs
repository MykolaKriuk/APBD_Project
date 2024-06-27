using APBD_Projekt.DTOs.FirmsDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Services.FirmServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FirmsController(IFirmService service) : ControllerBase
{
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddNewFirm (AddFirmRequestModel requestModel, 
        CancellationToken cancellationToken)
    {
        try
        {
            await service.AddNewFirmAsync(requestModel, cancellationToken);
        }
        catch (ExistingClientException e)
        {
            return Conflict(e.Message);
        }

        return Created();
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("update/{clientId}")]
    public async Task<IActionResult> UpdateFirm (int clientId, UpdateFirmRequestModel requestModel, 
        CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdatePrivateClientAsync(clientId, requestModel, cancellationToken);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }
}