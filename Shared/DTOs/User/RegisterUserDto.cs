using System.ComponentModel.DataAnnotations;
using Shared.DTOs.Enums;

namespace Shared.DTOs.User;

public class RegisterUserDto
{
    [MaxLength(100, ErrorMessage = "username length cannot be more than 100 characters")]
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "password is required")]
    public string Password { get; set; }

    public RoleTypeDto Role { get; set; }
}