using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Entities.Models.Enums;
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
        if (!clientDto.IsValid()) throw new CreateClientNotValidException();

        var client = new Client
        {
            Email = clientDto.Email,
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            PersonalNumber = clientDto.PersonalNumber,
            ProfilePhotoUrl = clientDto.ProfilePhotoUrl,
            PhoneNumber = clientDto.PhoneNumber,
            Sex = (GenderType)clientDto.Gender,
            Country = clientDto.Address.Country,
            City = clientDto.Address.City,
            Street = clientDto.Address.Street,
            ZipCode = clientDto.Address.ZipCode,
            Accounts = _mapper.Map<List<Account>>(clientDto.Accounts)
        };

       await _repositoryManager.ClientRepository.CreateAsync(client);
       await _repositoryManager.SaveAsync();
    }
}