using APBD_Projekt.DTOs.IncomeDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Services.IncomeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncomeController : ControllerBase
{
    private readonly IIncomeService service;

    public IncomeController(IIncomeService service)
    {
        this.service = service;
    }
    [Authorize]
    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentIncome([FromQuery]IncomeRequestModel requestModel,
        CancellationToken cancellationToken, [FromQuery]string targetCurrency="PLN")
    {
        string response;
        try
        {
            response = await service.GetCurrentIncome(targetCurrency, requestModel, cancellationToken);
        }
        catch (SoftwareNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return Ok(response);
    }
    
    [Authorize]
    [HttpGet("planned")]
    public async Task<IActionResult> GetPlannedIncome([FromQuery]IncomeRequestModel requestModel,
        CancellationToken cancellationToken, [FromQuery]string targetCurrency="PLN")
    {
        string response;
        try
        {
            response = await service.GetPlannedIncome(targetCurrency, requestModel, cancellationToken);
        }
        catch (SoftwareNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return Ok(response);
    }
}