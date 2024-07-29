using AutoMapper;
using Entities.Models;
using Shared.DTOs.Client;
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
    }
}