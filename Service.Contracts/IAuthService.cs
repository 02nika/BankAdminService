using Entities.Models.Enums;

namespace Service.Contracts;

public interface IAuthService
{
    string GenerateJwtToken(RoleType role);
}