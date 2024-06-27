using APBD_Projekt.DTOs.PaymentDTOs;

namespace APBD_Projekt.Services.PaymentServices;

public class PaymentService : IPaymentService
{
    public Task PayTheGivenAmountForTheContractAsync(PaymentRequestModel requestModel, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}