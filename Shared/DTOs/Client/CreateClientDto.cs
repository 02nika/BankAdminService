using System.ComponentModel.DataAnnotations;
using Shared.Attributes;
using Shared.DTOs.Enums;
using Shared.Extensions;

namespace Shared.DTOs.Client;

public class CreateClientDto
{
    [Required(ErrorMessage = "email is a required field")]
    [MaxLength(60, ErrorMessage = "email length cannot be more than 60 characters")]
    public string Email { get; set; }
    
    [MaxLength(60, ErrorMessage = "first name length cannot be more than 60 characters")]
    [Required(ErrorMessage = "first name is a required field")]
    public string FirstName { get; set; }

    [MaxLength(60, ErrorMessage = "last name length cannot be more than 60 characters")]
    [Required(ErrorMessage = "last name is a required field")]
    public string LastName { get; set; }

    [ExactLength(11)]
    [Required(ErrorMessage = "personal id is a required field")]
    public string PersonalNumber { get; set; }
    
    public string ProfilePhotoUrl { get; set; }

    [Required(ErrorMessage = "mobile phone is a required field")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "gender is a required field")]
    public GenderTypeDto Gender { get; set; }

    [Required(ErrorMessage = "address is a required field")]
    public AddressDto Address { get; set; }
    
    [LengthMoreThan(0)]
    public List<AccountDto> Accounts { get; set; }

    public bool IsValid()
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(this);
        var isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);
        
        return isValid && PhoneNumber.PhoneNumberIsValid(Address.Country);
    }
}

public class AccountDto
{
    [Required(ErrorMessage = "Account code is required")]
    [MaxLength(100, ErrorMessage = "code length cannot be more than 100 characters")]
    public string Code { get; set; }
}

public class AddressDto
{
    [MaxLength(50, ErrorMessage = "country length cannot be more than 60 characters")]
    public string Country { get; set; }
    
    [MaxLength(50, ErrorMessage = "city length cannot be more than 60 characters")]
    public string City { get; set; }
    
    [MaxLength(50, ErrorMessage = "street length cannot be more than 60 characters")]
    public string Street { get; set; }
    
    [MaxLength(50, ErrorMessage = "zip code length cannot be more than 60 characters")]
    public string ZipCode { get; set; }
}