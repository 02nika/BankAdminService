using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Enums;

namespace Entities.Models;

[Table("Users", Schema = "backend")]
public class User
{
    public Guid Id { get; set; }

    [MaxLength(100, ErrorMessage = "username length cannot be more than 100 characters")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "password is required")]
    [MaxLength(64)]
    public string PasswordHash { get; set; }
    public RoleType Role { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
