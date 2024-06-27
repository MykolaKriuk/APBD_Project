using APBD_Projekt.DTOs.PrivateClientDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Services.PrivateClientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PrivateClientsController(IPrivateClientService service) : ControllerBase
{
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddNewPrivateClient
        (AddPrivateClientRequestModel clientRequestModel, CancellationToken cancellationToken)
    {
        try
        {
            await service.AddNewPrivateClientAsync(clientRequestModel, cancellationToken);
        }
        catch (ExistingClientException e)
        {
            return Conflict(e.Message);
        }

        return Created();
    }

    [Authorize(Roles = "admin")]
    [HttpPut("update/{clientId}")]
    public async Task<IActionResult> UpdatePrivateClient(int clientId, 
        UpdatePrivateClientRequestModel clientRequestModel, CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdatePrivateClientAsync(clientId, clientRequestModel, cancellationToken);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }

    [Authorize(Roles = "admin")]
    [HttpDelete("delete/{clientId}")]
    public async Task<IActionResult> DeletePrivateClient(int clientId, 
        CancellationToken cancellationToken)
    {
        try
        {
            await service.DeletePrivateClientAsync(clientId, cancellationToken);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }
}