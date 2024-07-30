using AutoMapper;
using Microsoft.Extensions.Options;
using Repository.Contracts;
using Service.Contracts;
using Shared.Config;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthService> _authService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IClientService> _clientService;
    private readonly Lazy<IClientSuggestionService> _clientSuggestionService;


    public ServiceManager(
        IRepositoryManager repositoryManager,
        IMapper mapper,
        IOptions<ConfigSettings> jwtSettings
    )
    {
        _authService = new Lazy<IAuthService>(() => new AuthService(jwtSettings));
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
        _clientService = new Lazy<IClientService>(() => new ClientService(repositoryManager, mapper));
        _clientSuggestionService = new Lazy<IClientSuggestionService>(() => new ClientSuggestionService(repositoryManager, mapper));
    }
    
    public IAuthService AuthService => _authService.Value;
    public IUserService UserService => _userService.Value;
    public IClientService ClientService  => _clientService.Value;
    public IClientSuggestionService ClientSuggestionService  => _clientSuggestionService.Value;
}