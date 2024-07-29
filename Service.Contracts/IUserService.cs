using Shared.DTOs.User;

namespace Service.Contracts;

public interface IUserService
{
    Task RegisterUserAsync(RegisterUserDto userDto);

    Task<UserDto> GetUserAsync(LoginUserDto userDto);
}