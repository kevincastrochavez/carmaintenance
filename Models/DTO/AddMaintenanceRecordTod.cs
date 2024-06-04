using System.ComponentModel.DataAnnotations;

namespace CarMaintenance.Repositories;

public class AddMaintenanceRecordDto
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    [Range(1, 600000, ErrorMessage = "Miles must be between 0 and 600000")]
    public int Miles { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Component { get; set; }
    [Required]
    public Guid CarId { get; set; }
}