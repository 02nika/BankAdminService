using Entities.Models;

namespace Repository.Extensions;

public static class ClientExtensions
{
    public static IQueryable<Client> FilterByEmail(this IQueryable<Client> clients, string? email)
    {
        if (string.IsNullOrWhiteSpace(email)) return clients;

        return clients.Where(client => client.Email != null && client.Email.Equals(email));
    }
    
    public static IQueryable<Client> FilterByFirstName(this IQueryable<Client> clients, string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) return clients;

        return clients.Where(client => client.FirstName != null && client.FirstName.Equals(name));
    }
    
    public static IQueryable<Client> FilterByLastName(this IQueryable<Client> clients, string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) return clients;

        return clients.Where(client => client.LastName != null && client.LastName.Equals(name));
    }
    
    public static IQueryable<Client> Sort(this IQueryable<Client> clients, bool orderBy)
    {
        if (!orderBy) return clients;

        return clients
            .OrderByDescending(branch => branch.Email == null)
            .ThenByDescending(branch => branch.FirstName == null)
            .ThenByDescending(branch => branch.LastName == null)
            .ThenByDescending(branch => branch.PersonalNumber == null)
            .ThenByDescending(branch => branch.Country == null);
    }
}