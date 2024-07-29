using Shared.DTOs.Enums;

namespace Shared.DTOs.Client;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public RoleTypeDto Role { get; set; }
    public DateTime CreatedAt { get; set; }
}