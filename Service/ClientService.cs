using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts;
using Shared.DTOs.Client;

namespace Service;

public class ClientService : IClientService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ClientService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateClientDto clientDto)
    {
        if (!clientDto.IsValid(out var errorMessage)) throw new CreateClientNotValidException(errorMessage);

        var client = _mapper.Map<Client>(clientDto);

       await _repositoryManager.ClientRepository.CreateAsync(client);
       await _repositoryManager.SaveAsync();
    }

    public async Task<List<ClientDto>> GetAsync(FetchClientParams clientParams)
    {
        var clients = await _repositoryManager.ClientRepository.GetAsync(clientParams);

        return _mapper.Map<List<ClientDto>>(clients);
    }
}