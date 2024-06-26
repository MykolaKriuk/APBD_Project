using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Payments")]
public class Payment
{
    [Key]
    [Column("Payment_ID")]
    public int PaymentId { get; set; }
    
    [Column("Client_ID")]
    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    
    public Client Client { get; set; }
    
    [Column("Contract_ID")]
    [ForeignKey(nameof(Contract))]
    public int ContractId { get; set; }
    
    public Contract Contract { get; set; }
    
    [Column("Amount", TypeName = "money")]
    public decimal Amount { get; set; }
    
    [Column("Date")]
    public DateTime Date { get; set; }
}