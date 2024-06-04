using CarMaintenance.Data;
using CarMaintenance.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Repositories;

public class SQLServerUserRepository : IUserRepository
{
    private readonly CarsDbContext _context;
    public SQLServerUserRepository(CarsDbContext context)
    {
        this._context = context;
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await _context.Users
            .Include(u => u.Cars)
            .ThenInclude(c => c.MaintenanceRecords)
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}