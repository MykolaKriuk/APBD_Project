using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Contracts")]
public class Contract
{
    [Key]
    [Column("Contract_ID")]
    public int ContractId { get; set; }
    
    [Column("Client_ID")]
    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    
    public Client Client { get; set; }
    
    [Column("Price", TypeName = "money")]
    public decimal ContractPrice { get; set; }
    
    [Column("Date_From")]
    public DateTime ContractDateFrom { get; set; }
    
    [Column("Date_To")]
    public DateTime ContractDateTo { get; set; }
    
    [Column("Actualisation")]
    public int? ContractActualisation { get; set; }
    
    [Column("Version_ID")]
    [ForeignKey(nameof(SoftwareVersion))]
    public int SoftwareVersionId { get; set; }
    
    public SoftwareVersion SoftwareVersion { get; set; }

    [Column("Is_Signed")]
    public bool IsSigned { get; set; }

    public ICollection<Payment> Payments { get; set; }
}