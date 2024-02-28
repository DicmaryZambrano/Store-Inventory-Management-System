using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models;

public class Report
{
    [Key]
    public int ReportID { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the report name")]
    public string? ReportName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the content")]
    public string? Content { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    /* Other attributes that can be added

    public int GeneratedBy { get; set; } // Foreign Key referencing EmployeeID from Employees table

    public string Description { get; set; } = string.Empty;

    */
}
