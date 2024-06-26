using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("Category_ID")]
    public int CategoryId { get; set; }
    
    [Column("Name")]
    [MaxLength(50)]
    public string CategoryName { get; set; }

    public ICollection<SoftwareSystem> SoftwareSystems { get; set; }
}