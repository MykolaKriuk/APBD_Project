using APBD_Projekt.Contexts;
using APBD_Projekt.DTOs.PaymentDTOs;
using APBD_Projekt.Exceptions;
using APBD_Projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Projekt.Services.PaymentServices;

public class PaymentService(IncManagerContext context) : IPaymentService
{
    public async Task PayTheGivenAmountForTheContractAsync(PaymentRequestModel requestModel, CancellationToken cancellationToken)
    {
        var existingClient = await context.Clients
            .Include(c => c.Payments)
            .FirstOrDefaultAsync(c => c.ClientId == requestModel.ClientId, cancellationToken);
        if (existingClient is null)
        {
            throw new ClientNotFoundException
                ($"Client with id {requestModel.ClientId} does not exist");
        }
        
        var existingContract = await context.Contracts
            .Include(c => c.Payments)
            .FirstOrDefaultAsync(c => c.ContractId == requestModel.ContractId && !c.IsSigned, cancellationToken);
        if (existingContract is null)
        {
            throw new ContractNotFoundException($"Contract of id {requestModel.ContractId} does not exist");
        }

        if (DateTime.Now > existingContract.ContractDateTo)
        {
            context.Payments.RemoveRange(existingClient.Payments);
            await context.SaveChangesAsync(cancellationToken);
            throw new ContractDeadlineException("The deadline of the contract is expired. Refund is proceeded");
        }

        if (existingContract.IsSigned)
        {
            throw new ContractAlreadySignedException("The contract is already payed and signed");
        }

        var sumOfPayments = context.Payments
            .Where(p => p.ClientId == requestModel.ClientId &&
                        p.ContractId == requestModel.ContractId)
            .Select(p => p.Amount)
            .Sum();
        
        if (sumOfPayments + requestModel.PaymentAmount > existingContract.ContractPrice)
        {
            throw new TooBigPaymentAmountException(
                $"The amount payed for the contract is bigger then its price - {existingContract.ContractPrice} pln");
        }

        var newPayment = new Payment
        {
            Client = existingClient,
            Contract = existingContract,
            Amount = requestModel.PaymentAmount,
            Date = DateTime.Now
        };

        await context.Payments.AddAsync(newPayment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        sumOfPayments = context.Payments
            .Where(p => p.ClientId == requestModel.ClientId &&
                        p.ContractId == requestModel.ContractId)
            .Select(p => p.Amount)
            .Sum();
        if (sumOfPayments == existingContract.ContractPrice)
        {
            existingContract.IsSigned = true;
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}