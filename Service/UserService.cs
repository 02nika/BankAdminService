using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts;
using Shared.DTOs.Client;
using Shared.Extensions;

namespace Service;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _mapper = mapper;
        _repositoryManager = repositoryManager;
    }
    
    public async Task RegisterUserAsync(RegisterUserDto userDto)
    {
        var user = await _repositoryManager.UserRepository.GetAsync(userDto.Name);
        if (user != null) throw new UserAlreadyExistsException();
        
        var userEntity = _mapper.Map<User>(userDto);
        
        await _repositoryManager.UserRepository.CreateAsync(userEntity);
        await _repositoryManager.SaveAsync();
    }

    public async Task<UserDto> GetUserAsync(LoginUserDto userDto)
    {
        var user = await _repositoryManager.UserRepository.GetAsync(userDto.Name, userDto.Password.ComputeSha256Hash());

        if (user == null) throw new UserAlreadyExistsException();
        
        return _mapper.Map<UserDto>(user);
    }
}