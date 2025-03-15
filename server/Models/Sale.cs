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

    // Navigation properties
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;

    [ForeignKey("SalespersonId")]
    public Salesperson Salesperson { get; set; } = null!;
    
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; } = null!;
}