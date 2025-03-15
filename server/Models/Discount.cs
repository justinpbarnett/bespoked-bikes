using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class Discount
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }

    [Required]
    public DateTime BeginDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal DiscountPercentage { get; set; }

    // Navigation properties
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
}