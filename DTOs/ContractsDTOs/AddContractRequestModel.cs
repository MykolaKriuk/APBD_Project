using System.ComponentModel.DataAnnotations;

namespace APBD_Projekt.DTOs.ContractsDTOs;

public class AddContractRequestModel
{
    [Required]
    public int ClientId { get; set; }
    
    [Required]
    public int VersionId { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime DateFrom { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime DateTo { get; set; }
    
    public int? Actualisation { get; set; }
}