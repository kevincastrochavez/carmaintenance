using CarMaintenance.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Data;

public class CarsDbContext : DbContext
{

    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options) { }
    public DbSet<Car> Cars { get; set; }
}