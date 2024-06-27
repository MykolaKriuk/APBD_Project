using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Workers")]
public class Worker
{
    [Key]
    [Column("Worker_ID")]
    public int WorkerId { get; set; }
    
    [Column("Login")]
    [MaxLength(50)]
    public string WorkerLogin { get; set; }
    
    [Column("Email")]
    [MaxLength(50)]
    [EmailAddress(ErrorMessage = "Invalid e-mail format")]
    public string WorkerEmail { get; set; }

    [Column("Role")]
    [MaxLength(20)]
    public string WorkerRole { get; set; }
    
    [Column("Hashed_Password")]
    [MaxLength(64)]
    public string HashedPassword { get; set; }
    
    [Column("Salt")]
    [MaxLength(100)]
    public string Salt { get; set; }
    
    [Column("Refresh_Token")]
    [MaxLength(256)]
    public string RefreshToken { get; set; }
    
    [Column("Refresh_Token_Exp")]
    public DateTime RefreshTokenExp { get; set; }
}