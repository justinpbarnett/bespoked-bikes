using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Discount
{
    [Key]
    public int Id { get; set; }

    public int? ProductId { get; set; }

    [Required]
    public DateTime BeginDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal DiscountPercentage { get; set; }

    // Optional discount code that must be entered to apply the discount
    public string? DiscountCode { get; set; }

    // Computed properties
    public bool IsGlobal => ProductId == null;
    public bool RequiresCode => !string.IsNullOrEmpty(DiscountCode);

    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}