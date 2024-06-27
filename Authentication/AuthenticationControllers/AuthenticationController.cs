using APBD_Projekt.Authentication.AuthenticationDTOs;
using APBD_Projekt.Authentication.AuthenticationServices;
using APBD_Projekt.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Authentication.AuthenticationControllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IAutService service) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterWorker(RegisterWorkerRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        await service.RegisterNewWorkerAsync(requestModel, cancellationToken);
        return Created();
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginWorker(LoginWorkerRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        string response;
        try
        {
            response = await service.LoginWorkerAsync(requestModel, cancellationToken);
        }
        catch (UnauthorizedWorkerException e)
        {
            return Unauthorized(e.Message);
        }

        return Ok(response);
    }
}