using Entities.Models;
using Shared.DTOs.Client;

namespace Repository.Contracts;

public interface IClientRepository
{
    Task CreateAsync(Client client);
    Task<List<Client>> GetAsync(FetchClientParams clientParams);
    Task<Client?> GetAsync(Guid id);
}