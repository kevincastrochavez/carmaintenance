using CarMaintenance.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarMaintenance.Data;

public class CarsDbContext : DbContext
{

    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mock Car data
        var users = new List<User>
        {
            new User { UserId = "user1", UserName = "Alice" },
            new User { UserId = "user2", UserName = "Bob" }
        };

        // Mock Car data
        var cars = new List<Car>
        {
            new Car { CarId = Guid.NewGuid(), CarName = "Toyota Camry", CurrentMiles = 120000, UserId = "user1" },
            new Car { CarId = Guid.NewGuid(), CarName = "Honda Civic", CurrentMiles = 90000, UserId = "user1" },
            new Car { CarId = Guid.NewGuid(), CarName = "Ford Focus", CurrentMiles = 70000, UserId = "user2" },
            new Car { CarId = Guid.NewGuid(), CarName = "Chevrolet Malibu", CurrentMiles = 50000, UserId = "user2" },
            new Car { CarId = Guid.NewGuid(), CarName = "Nissan Altima", CurrentMiles = 30000, UserId = "user2" }
        };

        // Mock MaintenanceRecord data
        var maintenanceRecords = new List<MaintenanceRecord>
        {
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2022, 1, 15), Miles = 115000, Type = "Change", Component = "EngineOil", CarId = cars[0].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2022, 6, 10), Miles = 118000, Type = "Check", Component = "TransmissionFluid", CarId = cars[0].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2021, 3, 20), Miles = 85000, Type = "Change", Component = "EngineOil", CarId = cars[1].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2021, 9, 5), Miles = 88000, Type = "Check", Component = "Brakes", CarId = cars[1].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2023, 2, 11), Miles = 68000, Type = "Change", Component = "EngineOil", CarId = cars[2].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2023, 8, 8), Miles = 70000, Type = "Check", Component = "Tires", CarId = cars[2].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2022, 7, 14), Miles = 45000, Type = "Change", Component = "EngineOil", CarId = cars[3].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2022, 12, 25), Miles = 47000, Type = "Check", Component = "Battery", CarId = cars[3].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2021, 11, 17), Miles = 25000, Type = "Change", Component = "EngineOil", CarId = cars[4].CarId },
            new MaintenanceRecord { MaintenanceRecordId = Guid.NewGuid(), Date = new DateTime(2022, 5, 30), Miles = 28000, Type = "Check", Component = "AirFilter", CarId = cars[4].CarId }
        };

        modelBuilder.Entity<User>().HasData(users);
        modelBuilder.Entity<Car>().HasData(cars);
        modelBuilder.Entity<MaintenanceRecord>().HasData(maintenanceRecords);
    }
}