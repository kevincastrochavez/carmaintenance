using CarMaintenance.Models.Domain;

namespace CarMaintenance.Repositories;

public interface ICarRepository
{
    Task<List<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(Guid id);
    // Task<Car> CreateAsync(Car car);
    // Task<Car?> UpdateAsync(Guid id, Car car);
    // Task<Car?> DeleteAsync(Guid id);
}