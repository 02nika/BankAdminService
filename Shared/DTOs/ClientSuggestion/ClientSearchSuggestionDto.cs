using Shared.DTOs.Enums;

namespace Shared.DTOs.ClientSuggestion;

public class ClientSearchSuggestionDto
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }
    public string PhoneNumber { get; set; }
    public GenderTypeDto Gender { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public bool OrderBy { get; set; }
}