using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;

namespace Repository;

public class ClientSearchSuggestionsRepository : RepositoryBase<ClientSearchSuggestion>, IClientSearchSuggestionsRepository
{
    public ClientSearchSuggestionsRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public Task CreateAsync(ClientSearchSuggestion suggestion) => Create(suggestion);
    
    public async Task<List<ClientSearchSuggestion>> GetAsync(Guid userId)
    {
        return await FindByCondition(suggestion => suggestion.UserId == userId, false)
            .OrderByDescending(suggestion => suggestion.Id)
            .Take(3)
            .ToListAsync();
    }
}