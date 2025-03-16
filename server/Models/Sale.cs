using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int SalespersonId { get; set; }

    public int CustomerId { get; set; }

    [Required]
    public DateTime SalesDate { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal SalePrice { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal CommissionAmount { get; set; }

    public int? AppliedDiscountId { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal AppliedDiscountPercentage { get; set; } = 0;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal OriginalPrice { get; set; }

    public string? AppliedDiscountCode { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;

    [ForeignKey("SalespersonId")]
    public Salesperson Salesperson { get; set; } = null!;

    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; } = null!;

    [ForeignKey("AppliedDiscountId")]
    public Discount? AppliedDiscount { get; set; }
}