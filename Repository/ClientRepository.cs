using Entities.Models;
using Repository.Context;
using Repository.Contracts;

namespace Repository;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public Task CreateAsync(Client client) => Create(client);
}