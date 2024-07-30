using Entities.Models;
using Entities.Models.Enums;
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
        var clients = await FindByCondition(client => client.DeletedAt == null, false)
            .FilterByEmail(clientParams.FirstName)
            .FilterByFirstName(clientParams.FirstName)
            .FilterByLastName(clientParams.LastName)
            .FilterByPersonalNumber(clientParams.PersonalNumber)
            .FilterByPhoneNumber(clientParams.PhoneNumber)
            .FilterByGender((GenderType)clientParams.Gender!)
            .Sort(clientParams.OrderBy)
            .Skip((clientParams.PageIndex - 1) * clientParams.PageSize)
            .Take(clientParams.PageSize)
            .Include(client => client.Accounts)
            .ToListAsync();

        return clients;
    }

    public async Task<Client?> GetAsync(Guid id) => await FindByCondition(client => client.DeletedAt == null && client.Id == id, true).FirstOrDefaultAsync();
}