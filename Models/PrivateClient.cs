using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Private_Clients")]
public class PrivateClient
{
    [Key]
    [Column("Client_ID")]
    [ForeignKey(nameof(Client))]
    public int PrivateClientId { get; set; }
    
    public Client Client { get; set; }
    
    [Column("First_Name")]
    [MaxLength(50)]
    public string ClientFirstName { get; set; }
    
    [Column("Last_Name")]
    [MaxLength(50)]
    public string ClientLastName { get; set; }
    
    [Column("Pesel")]
    [MaxLength(11)]
    public string ClientPesel { get; set; }
    
    [Column("Is_Deleted")]
    public bool IsDeleted { get; set; }
}