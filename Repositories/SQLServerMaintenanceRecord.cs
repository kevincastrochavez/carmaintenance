using CarMaintenance.Data;
using CarMaintenance.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Repositories;

public class SQLServerMaintenanceRecord : IMaintenanceRecordRepository
{
    private readonly CarsDbContext _context;
    public SQLServerMaintenanceRecord(CarsDbContext context)
    {
        this._context = context;
    }

    public async Task<List<MaintenanceRecord>> GetAllAsync()
    {
        return await _context.MaintenanceRecords.ToListAsync();
    }
}