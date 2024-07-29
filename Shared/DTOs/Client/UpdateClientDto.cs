using System.ComponentModel.DataAnnotations;
using Shared.DTOs.Enums;

namespace Shared.DTOs.Client;

public class UpdateClientDto
{
    [Required(ErrorMessage = "email is a required field")]
    [EmailAddress(ErrorMessage = "incorrect email format")]
    [MaxLength(50, ErrorMessage = "email length cannot be more than 50 characters")]
    public string Email { get; set; }
    
    [MaxLength(50, ErrorMessage = "first name length cannot be more than 50 characters")]
    public string? FirstName { get; set; }
    
    [MaxLength(50, ErrorMessage = "last name length cannot be more than 50 characters")]
    public string? LastName { get; set; }
    
    [MaxLength(11, ErrorMessage = "private number length cannot be more than 11 characters")]
    public string? PrivateNumber { get; set; }

    public GenderTypeDto? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    
    public Guid CitizenshipId { get; set; }
    
    [MaxLength(20, ErrorMessage = "phone number length cannot be more than 20 characters")]
    public string? PhoneNumber { get; set; }

    [MaxLength(5, ErrorMessage = "birth place length cannot be more than 5 characters")]
    public string? BirthPlace { get; set; }
    
    [MaxLength(100, ErrorMessage = "address length cannot be more than 100 characters")]
    public string? Address { get; set; }
}