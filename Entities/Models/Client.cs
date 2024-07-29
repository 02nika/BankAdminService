using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Enums;
using Shared.Attributes;

namespace Entities.Models;

[Table("Clients", Schema = "backend")]
public class Client
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "email is a required field")]
    public string Email { get; set; }

    [MaxLength(50, ErrorMessage = "first name length cannot be more than 60 characters")]
    public string FirstName { get; set; }

    [MaxLength(50, ErrorMessage = "last name length cannot be more than 60 characters")]
    public string LastName { get; set; }

    [ExactLength(11)] 
    public string PersonalNumber { get; set; }
    
    [MaxLength(100)]
    public string ProfilePhotoUrl { get; set; }

    [MaxLength(20, ErrorMessage = "phone number length cannot be more than 20 characters")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "gender is required")]
    public GenderType Sex { get; set; }

    [MaxLength(50, ErrorMessage = "country length cannot be more than 60 characters")]
    public string Country { get; set; }
    
    [MaxLength(50, ErrorMessage = "city length cannot be more than 60 characters")]
    public string City { get; set; }
    
    [MaxLength(50, ErrorMessage = "street length cannot be more than 60 characters")]
    public string Street { get; set; }
    
    [MaxLength(50, ErrorMessage = "zip code length cannot be more than 60 characters")]
    public string ZipCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public ICollection<Account> Accounts { get; set; } = [];
}