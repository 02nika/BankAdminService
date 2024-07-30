using Shared.DTOs.Enums;

namespace Shared.DTOs.Client;

public class ClientDto
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PersonalNumber { get; set; }
    
    public string ProfilePhotoUrl { get; set; }

    public string PhoneNumber { get; set; }

    public GenderTypeDto Gender { get; set; }

    public string Country { get; set; }
    
    public string City { get; set; }
    
    public string Street { get; set; }
    
    public string ZipCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public ICollection<AccountDto> Accounts { get; set; } = [];
}