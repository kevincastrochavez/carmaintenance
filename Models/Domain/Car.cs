namespace CarMaintenance.Models.Domain;

public class Car
{
    public Guid CarId { get; set; }
    public string CarName { get; set; }
    public int CurrentMiles { get; set; }
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
    public string UserId { get; set; }
}

