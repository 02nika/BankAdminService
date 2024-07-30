using Shared.DTOs.Client;
using Shared.DTOs.ClientSuggestion;

namespace Service.Contracts;

public interface IClientSuggestionService
{
    Task CreateAsync(FetchClientParams suggestionDto, Guid userId);
    Task<List<ClientSearchSuggestionDto>> GetAsync(Guid userId);
}