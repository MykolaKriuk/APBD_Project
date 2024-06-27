using APBD_Projekt.DTOs.PaymentDTOs;

namespace APBD_Projekt.Services.PaymentServices;

public interface IPaymentService
{
    public Task PayTheGivenAmountForTheContractAsync(PaymentRequestModel requestModel,
        CancellationToken cancellationToken);
}