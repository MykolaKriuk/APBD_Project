using System.ComponentModel.DataAnnotations;

namespace APBD_Projekt.Authentication.AuthenticationDTOs;

public class LoginWorkerRequestModel
{
    [Required]
    [MaxLength(50)]
    public string Login { get; set; }
    
    [Required]
    public string Password { get; set; }
}