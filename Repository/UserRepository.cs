using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
    
    public Task CreateAsync(User user) => Create(user);

    public async Task<User?> GetAsync(string userName)
    {
        return await FindByCondition(user => user.DeletedAt == null && user.UserName == userName, false).SingleOrDefaultAsync();
    }
    
    public async Task<User?> GetAsync(string userName, string passwordHash)
    {
        return await FindByCondition(user => user.DeletedAt == null && user.UserName == userName && user.PasswordHash == passwordHash,
            false).SingleOrDefaultAsync();
    }
}