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

    public async Task<Car> CreateAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task<Car?> UpdateAsync(Guid id, Car car)
    {
        var carToUpdate = await _context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
        if (carToUpdate == null)
        {
            return null;
        }

        // Update properties
        carToUpdate.CarName = car.CarName;
        carToUpdate.CurrentMiles = car.CurrentMiles;
        carToUpdate.UserId = car.UserId;

        await _context.SaveChangesAsync();
        return carToUpdate;
    }
}