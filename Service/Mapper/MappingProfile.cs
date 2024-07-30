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

        CreateMap<AccountDto, Account>().ReverseMap();

        CreateMap<GenderType, GenderTypeDto>().ReverseMap();
        
        CreateMap<CreateClientDto, Client>()
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Sex));
        
    }
}