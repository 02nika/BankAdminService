using Shared.DTOs.Client;

namespace Service.Contracts;

public interface IClientService
{
    Task CreateAsync(CreateClientDto clientDto);
    Task<List<ClientDto>> GetAsync(FetchClientParams clientParams);
}
