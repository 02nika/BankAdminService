using Repository.Context;
using Repository.Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _appDbContext;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IClientRepository> _clientRepository;
    private readonly Lazy<IClientSearchSuggestionsRepository> _clientSearchSuggestionsRepository;
    
    public RepositoryManager(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _userRepository =
            new Lazy<IUserRepository>(() => new UserRepository(appDbContext));
        _clientRepository =
            new Lazy<IClientRepository>(() => new ClientRepository(appDbContext));
        _clientSearchSuggestionsRepository =
            new Lazy<IClientSearchSuggestionsRepository>(() => new ClientSearchSuggestionsRepository(appDbContext));
    }

    public IUserRepository UserRepository => _userRepository.Value;
    public IClientRepository ClientRepository => _clientRepository.Value;
    public IClientSearchSuggestionsRepository ClientSearchSuggestions => _clientSearchSuggestionsRepository.Value;

    public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();
}