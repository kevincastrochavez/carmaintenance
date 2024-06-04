using System.ComponentModel.DataAnnotations;

namespace CarMaintenance.Repositories;

public class AddUserDto
{
    public string UserId { get; set; }
    [Required]
    // Since creation of user will be internally according to the IdentyityUser string Id, no need for validation
    public string UserName { get; set; }
}