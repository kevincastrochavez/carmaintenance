using CarMaintenance.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Models.Domain;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly CarsDbContext _context;
    public UsersController(CarsDbContext context)
    {
        this._context = context;
    }

    // GET: api/User
    [HttpGet("{userId}")]
    public async Task<ActionResult<User>> GetUser(string userId)
    {
        return await _context.Users
            .Include(u => u.Cars)
            .ThenInclude(c => c.MaintenanceRecords)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }
}