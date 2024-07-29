using AutoMapper;
using Entities.Models;
using Entities.Models.Enums;
using Shared.DTOs.Client;
using Shared.DTOs.Enums;
using Shared.DTOs.User;
using Shared.Extensions;

namespace Service.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterUserDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt
                .MapFrom(src => src.Password.ComputeSha256Hash()))
            .ForMember(dest => dest.UserName, opt => opt
            .MapFrom(src => src.Name));

        CreateMap<User, UserDto>();
        
        CreateMap<AccountDto, Account>();
    }
}