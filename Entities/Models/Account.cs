using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("Accounts", Schema = "backend")]
public class Account
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "ClientId is required")]
    public Guid ClientId { get; set; }

    [Required(ErrorMessage = "Account code is required")]
    [MaxLength(100, ErrorMessage = "code length cannot be more than 100 characters")]
    public string Code { get; set; }
    
    [ForeignKey("ClientId")] 
    public Client Client { get; set; }
}