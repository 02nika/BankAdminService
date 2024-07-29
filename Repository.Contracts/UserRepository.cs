using Entities.Models;

namespace Repository.Contracts;

public interface IUserRepository
{
    Task CreateAsync(User user);

    Task<User?> GetAsync(string userName);
    Task<User?> GetAsync(string userName, string passwordHash);
}