using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.User;

public class LoginUserDto
{
    [MaxLength(100, ErrorMessage = "username length cannot be more than 100 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "password is required")]
    public string Password { get; set; }   
}