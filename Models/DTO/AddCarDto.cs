using System.ComponentModel.DataAnnotations;

namespace CarMaintenance.Repositories;

public class AddCarDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Car name must be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Car name must be less than 50 characters long")]
    public string CarName { get; set; }
    [Required]
    [Range(0, 600000, ErrorMessage = "Miles must be between 0 and 600000")]
    public int CurrentMiles { get; set; }
    [Required]
    public string UserId { get; set; }
}