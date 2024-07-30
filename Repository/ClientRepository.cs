using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;
using Repository.Extensions;
using Shared.DTOs.Client;

namespace Repository;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public Task CreateAsync(Client client) => Create(client);

    public async Task<List<Client>> GetAsync(FetchClientParams clientParams)
    {
        var liens = await FindByCondition(lien => lien.DeletedAt == null, false)
            .FilterByEmail(clientParams.FirstName)
            .FilterByFirstName(clientParams.FirstName)
            .FilterByLastName(clientParams.LastName)
            .Sort(clientParams.OrderBy)
            .Skip((clientParams.PageIndex - 1) * clientParams.PageSize)
            .Take(clientParams.PageSize)
            .Include(client => client.Accounts)
            .ToListAsync();

        return liens;
    }
}