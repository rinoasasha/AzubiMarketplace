using AutoMapper;
using backend.Models.DTOs;
using backend.Models;


namespace backend.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<User, UserEditDTO>();
        CreateMap<AzubiRequest, AzubiRequestDTO>();
        CreateMap<ABBResponse, ABBResponseDTO>();
    }
}