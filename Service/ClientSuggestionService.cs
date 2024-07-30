using AutoMapper;
using Entities.Models;
using Entities.Models.Enums;
using Repository.Contracts;
using Service.Contracts;
using Shared.DTOs.Client;
using Shared.DTOs.ClientSuggestion;

namespace Service;

public class ClientSuggestionService : IClientSuggestionService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ClientSuggestionService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    
    public async Task CreateAsync(FetchClientParams suggestionDto, Guid userId)
    {
        var suggestion = new ClientSearchSuggestion
        {
            UserId = userId,
            Email = suggestionDto.Email,
            FirstName = suggestionDto.FirstName,
            LastName = suggestionDto.LastName,
            PersonalNumber = suggestionDto.PersonalNumber,
            PhoneNumber = suggestionDto.PhoneNumber,
            Gender = _mapper.Map<GenderType>(suggestionDto.Gender),
            PageIndex = suggestionDto.PageIndex,
            PageSize = suggestionDto.PageSize,
            OrderBy = suggestionDto.OrderBy,
        };
            
        await _repositoryManager.ClientSearchSuggestions.CreateAsync(suggestion);
        await _repositoryManager.SaveAsync();
    }

    public async Task<List<ClientSearchSuggestionDto>> GetAsync(Guid userId)
    {
        var searchSuggestions = await _repositoryManager.ClientSearchSuggestions.GetAsync(userId);

        return _mapper.Map<List<ClientSearchSuggestionDto>>(searchSuggestions);
    }
}