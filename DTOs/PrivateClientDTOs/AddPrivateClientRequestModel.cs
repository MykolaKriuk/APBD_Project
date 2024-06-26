using System.ComponentModel.DataAnnotations;

namespace APBD_Projekt.DTOs.PrivateClientDTOs;

public class AddPrivateClientRequestModel
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(11)]
    public string Pesel { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Address { get; set; }
    
    [Required]
    [MaxLength(50)]
    [EmailAddress(ErrorMessage = "Invalid e-mail format")]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(9)]
    public string TelNum { get; set; }
}