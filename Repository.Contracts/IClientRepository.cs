using Entities.Models;

namespace Repository.Contracts;

public interface IClientRepository
{
    Task CreateAsync(Client client);
}