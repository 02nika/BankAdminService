using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repository.Contracts;
using Service.Contracts;
using Shared.Config;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthService> _authService;
    private readonly Lazy<IUserService> _userService;


    public ServiceManager(
        IRepositoryManager repositoryManager,
        IConfiguration configuration,
        IMapper mapper,
        IServiceProvider serviceProvider,
        IOptions<ConfigSettings> jwtSettings
    )
    {
        _authService = new Lazy<IAuthService>(() => new AuthService(jwtSettings));
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
    }
    
    public IAuthService AuthService => _authService.Value;
    public IUserService UserService => _userService.Value;
}