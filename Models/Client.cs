using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Clients")]
public class Client
{
    [Key]
    [Column("Client_ID")]
    public int ClientId { get; set; }
    
    [Column("Address")]
    [MaxLength(100)]
    public string ClientAddress { get; set; }
    
    [Column("Email")]
    [MaxLength(50)]
    [EmailAddress(ErrorMessage = "Invalid e-mail format")]
    public string ClientEmail { get; set; }
    
    [Column("Tel_Num")]
    [MaxLength(9)]
    public string ClientTelNumber { get; set; }

    public ICollection<Payment> Payments { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}