using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Style { get; set; } = string.Empty;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal PurchasePrice { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal SalePrice { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int QuantityOnHand { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal CommissionPercentage { get; set; }

    // Navigation properties
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}