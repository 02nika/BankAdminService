using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Enums;

namespace Entities.Models;

[Table("ClientSearchSuggestions", Schema = "backend")]
public class ClientSearchSuggestion
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }
    public string PhoneNumber { get; set; }
    public GenderType Gender { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public bool OrderBy { get; set; }

    public User User { get; set; }
}