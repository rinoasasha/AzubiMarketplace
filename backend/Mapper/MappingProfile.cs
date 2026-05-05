using AutoMapper;
using backend.Models.DTOs;
using backend.Models;


namespace backend.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();
        CreateMap<AzubiRequest, AzubiRequestDTO>();
    }
}