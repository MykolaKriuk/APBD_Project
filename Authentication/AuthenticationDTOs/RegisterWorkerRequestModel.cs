using System.ComponentModel.DataAnnotations;

namespace APBD_Projekt.Authentication.AuthenticationDTOs;

public class RegisterWorkerRequestModel
{
    [Required]
    [MaxLength(50)]
    [EmailAddress(ErrorMessage = "Invalid e-mail format")]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Login { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Role { get; set; }
}