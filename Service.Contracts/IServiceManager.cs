namespace Service.Contracts;

public interface IServiceManager
{
    public IAuthService AuthService { get; }
    public IUserService UserService { get; }
    public IClientService ClientService { get; }
    public IClientSuggestionService ClientSuggestionService { get; }
}