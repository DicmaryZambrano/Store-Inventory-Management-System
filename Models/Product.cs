using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models;

/// <summary>
/// Represents a pre-configured template for a product
/// </summary>
public class Product
{
    [Key]
    public int ProductID { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a product name")]
    public string? ProductName { get; set; }

    [Range(0, double.MaxValue)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    public bool Discontinued { get; set; } = false;
    public DateTime CreatedDate { get; set; }
}
