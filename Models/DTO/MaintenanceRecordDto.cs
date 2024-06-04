namespace CarMaintenance.Repositories;

public class MaintenanceRecordDto
{
    public Guid MaintenanceRecordId { get; set; }
    public DateTime Date { get; set; }
    public int Miles { get; set; }
    public string Type { get; set; }
    public string Component { get; set; }

    public Guid CarId { get; set; }
}