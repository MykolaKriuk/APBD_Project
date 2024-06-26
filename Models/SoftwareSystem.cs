using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Software_Systems")]
public class SoftwareSystem
{
    [Key]
    [Column("Soft_ID")]
    public int SoftwareId { get; set; }
    
    [Column("Description")]
    [MaxLength(200)]
    public string SoftwareDescription { get; set; }
    
    [Column("Category_ID")]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }

    public ICollection<SoftwareVersion> SoftwareVersions { get; set; }
    
    public ICollection<SoftwareDiscount> SoftwareDiscounts { get; set; }
}