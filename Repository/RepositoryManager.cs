using Repository.Context;
using Repository.Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _appDbContext;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IClientRepository> _clientRepository;
    
    public RepositoryManager(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _userRepository =
            new Lazy<IUserRepository>(() => new UserRepository(appDbContext));
        _clientRepository =
            new Lazy<IClientRepository>(() => new ClientRepository(appDbContext));
    }

    public IUserRepository UserRepository => _userRepository.Value;
    public IClientRepository ClientRepository => _clientRepository.Value;

    public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();
}