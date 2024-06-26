using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_Projekt.Models;

[Table("Software_Discounts")]
[PrimaryKey(nameof(SoftwareId), nameof(DiscountId))]
public class SoftwareDiscount
{
    [Column("Software_ID")]
    [ForeignKey(nameof(SoftwareSystem))]
    public int SoftwareId { get; set; }
    
    public SoftwareSystem SoftwareSystem { get; set; }
    
    [Column("Discount_ID")]
    [ForeignKey(nameof(Discount))]
    public int DiscountId { get; set; }
    
    public Discount Discount { get; set; }
    
    [Column("Value")]
    public int DiscountValue { get; set; }
}