using CarMaintenance.Data;
using CarMaintenance.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Repositories;

public class SQLServerCarRepository : ICarRepository
{
    private readonly CarsDbContext _context;

    public SQLServerCarRepository(CarsDbContext context)
    {
        this._context = context;
    }

    public async Task<List<Car>> GetAllAsync()
    {
        return await _context.Cars.Include(c => c.MaintenanceRecords).ToListAsync();
    }

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        return await _context.Cars
            .Include(c => c.MaintenanceRecords)
            .FirstOrDefaultAsync(c => c.CarId == id);
    }
}