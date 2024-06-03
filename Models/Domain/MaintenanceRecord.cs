namespace CarMaintenance.Models.Domain;

public class MaintenanceRecord
{
    public Guid MaintenanceRecordId { get; set; }
    public DateTime Date { get; set; }
    public int Miles { get; set; }
    public string Type { get; set; } // "Check" or "Change"
    public string Component { get; set; } // e.g., "EngineOil", "TransmissionFluid"

    public Guid CarId { get; set; }
    // Navigation property
    public Car Car { get; set; }
}