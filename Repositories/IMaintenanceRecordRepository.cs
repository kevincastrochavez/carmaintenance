using CarMaintenance.Models.Domain;

namespace CarMaintenance.Repositories;

public interface IMaintenanceRecordRepository
{
    Task<List<MaintenanceRecord>> GetAllAsync();
    Task<MaintenanceRecord?> GetByIdAsync(Guid id);
    Task<MaintenanceRecord> CreateAsync(MaintenanceRecord maintenanceRecord);
    Task<MaintenanceRecord?> UpdateAsync(Guid id, MaintenanceRecord maintenanceRecord);
}