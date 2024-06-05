using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Data;

public class CarsAuthDbContext : IdentityDbContext
{
    public CarsAuthDbContext(DbContextOptions<CarsAuthDbContext> options) : base(options)
    {

    }
}