using Entities.Models;

namespace Repository.Contracts;

public interface IClientSearchSuggestionsRepository
{
    Task CreateAsync(ClientSearchSuggestion suggestion);

    Task<List<ClientSearchSuggestion>> GetAsync(Guid userId);
}