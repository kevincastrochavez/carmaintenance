using CarMaintenance.Models.Domain;

namespace CarMaintenance.Repositories;

public class CarDto
{
    public Guid CarId { get; set; }
    public string CarName { get; set; }
    public int CurrentMiles { get; set; }
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
}