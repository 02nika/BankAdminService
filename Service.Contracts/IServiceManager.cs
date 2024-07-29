namespace Service.Contracts;

public interface IServiceManager
{
    public IAuthService AuthService { get; }
    public IUserService UserService { get; }
}