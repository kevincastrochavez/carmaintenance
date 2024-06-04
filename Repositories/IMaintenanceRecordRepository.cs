using CarMaintenance.Models.Domain;

namespace CarMaintenance.Repositories;

public interface IMaintenanceRecordRepository
{
    Task<List<MaintenanceRecord>> GetAllAsync();

    Task<MaintenanceRecord?> GetByIdAsync(Guid id);
}