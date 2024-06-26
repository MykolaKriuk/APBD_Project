using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Software_Versions")]
public class SoftwareVersion
{
    [Key]
    [Column("Version_ID")]
    public int VersionId { get; set; }
    
    [Column("Software_ID")]
    [ForeignKey(nameof(SoftwareSystem))]
    public int SoftwareId { get; set; }
    
    public SoftwareSystem SoftwareSystem { get; set; }
    
    [Column("Version")]
    [MaxLength(20)]
    public string VersionNum { get; set; }
    
    [Column("Version_Info")]
    [MaxLength(200)]
    public string VersionInfo { get; set; }

    public ICollection<Contract> Contracts { get; set; }
}