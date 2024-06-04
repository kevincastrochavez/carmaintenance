namespace CarMaintenance.Models.Domain;

public class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public ICollection<Car> Cars { get; set; }
}