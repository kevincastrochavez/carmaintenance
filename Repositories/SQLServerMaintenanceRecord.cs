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

    public async Task<MaintenanceRecord?> GetByIdAsync(Guid id)
    {
        return await _context.MaintenanceRecords.FirstOrDefaultAsync(m => m.MaintenanceRecordId == id);
    }

    public async Task<MaintenanceRecord> CreateAsync(MaintenanceRecord maintenanceRecord)
    {
        await _context.MaintenanceRecords.AddAsync(maintenanceRecord);
        await _context.SaveChangesAsync();
        return maintenanceRecord;
    }

    public async Task<MaintenanceRecord?> UpdateAsync(Guid id, MaintenanceRecord maintenanceRecord)
    {
        var maintenanceRecordToUpdate = await _context.MaintenanceRecords.FirstOrDefaultAsync(m => m.MaintenanceRecordId == id);
        if (maintenanceRecordToUpdate == null)
        {
            return null;
        }

        // Update properties
        maintenanceRecordToUpdate.Date = maintenanceRecord.Date;
        maintenanceRecordToUpdate.Miles = maintenanceRecord.Miles;
        maintenanceRecordToUpdate.Type = maintenanceRecord.Type;
        maintenanceRecordToUpdate.Component = maintenanceRecord.Component;

        await _context.SaveChangesAsync();
        return maintenanceRecordToUpdate;
    }
}