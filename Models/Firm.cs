using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Firms")]
public class Firm
{
    [Key]
    [Column("Client_ID")]
    [ForeignKey(nameof(Client))]
    public int FirmId { get; set; }

    public Client Client { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string FirmName { get; set; }
    
    
    
    [Column("KRS")]
    [MaxLength(14)]
    public string FirmKRSNum { get; set; }
}