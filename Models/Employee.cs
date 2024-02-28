using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models;

/// <summary>
/// Represents a pre-configured template for a product
/// </summary>
/// 
public enum Position
{
    Manager,
    Employee
}

public class Employee
{
    [Key]
    public int EmployeeID { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the first name")]
    public string? FirstName { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? LastName { get; set; }

    [Required]
    [EnumDataType(typeof(Position))]
    public Position Position { get; set; } = Position.Employee;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide username")]
    public string? Username { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the password"), Compare(nameof(Password)), DataType(DataType.Password)]
    public string? Password { get; set; }
    public DateTime CreatedDate { get; set; }
}
