using System.ComponentModel.DataAnnotations;

namespace APBD_Projekt.DTOs.FirmsDTOs;

public class UpdateFirmRequestModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
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