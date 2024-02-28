using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models;

/// <summary>
/// Represents a pre-configured template for a product
/// </summary>
public class Store
{
    [Key]
    public int StoreID { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the store name")]
    public string? StoreName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the location")]
    public string? Location { get; set; }
    public DateTime CreatedDate { get; set; }
}
