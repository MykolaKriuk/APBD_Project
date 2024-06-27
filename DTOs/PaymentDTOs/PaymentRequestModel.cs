using System.ComponentModel.DataAnnotations;

namespace APBD_Projekt.DTOs.PaymentDTOs;

public class PaymentRequestModel
{
    [Required]
    public int ClientId { get; set; }
    
    [Required]
    public int ContractId { get; set; }
    
    [Required]
    public decimal PaymentAmount { get; set; }
}