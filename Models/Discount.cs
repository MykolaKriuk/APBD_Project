using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Projekt.Models;

[Table("Discounts")]
public class Discount
{
    [Key]
    [Column("Discount_ID")]
    public int DiscountId { get; set; }
    
    [Column("Name")]
    [MaxLength(20)]
    public string DiscountName { get; set; }
    
    [Column("Description")]
    [MaxLength(50)]
    public string DiscountDescription { get; set; }
    
    [Column("Date_From")]
    public DateTime DiscountDateFrom { get; set; }
    
    [Column("Date_To")]
    public DateTime DiscountDateTo { get; set; }

    public ICollection<SoftwareDiscount> SoftwareDiscounts { get; set; }
}