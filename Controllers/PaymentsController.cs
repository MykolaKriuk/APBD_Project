using APBD_Projekt.DTOs.PaymentDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Services.PaymentServices;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Projekt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController(IPaymentService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PayTheGivenAmountForTheContract(PaymentRequestModel requestModel,
        CancellationToken cancellationToken)
    {
        try
        {
            await service.PayTheGivenAmountForTheContractAsync(requestModel, cancellationToken);
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ContractNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ContractAlreadySignedException e)
        {
            return Conflict(e.Message);
        }
        catch (TooBigPaymentAmountException e)
        {
            return Conflict(e.Message);
        }
        catch (ContractDeadlineException e)
        {
            return StatusCode(StatusCodes.Status410Gone, e.Message);
        }

        return Created();
    }
}