using CarMaintenance.Models.Domain;

namespace CarMaintenance.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(string id);
    Task<User> CreateAsync(User user);
    Task<User?> DeleteAsync(string id);
}
