namespace CarMaintenance.Repositories;

public class UserDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public ICollection<CarDto> Cars { get; set; }
}