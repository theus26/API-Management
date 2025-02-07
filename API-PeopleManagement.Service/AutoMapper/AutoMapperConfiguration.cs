using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Entities;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(ps =>
        {
            ps.AddProfile(new DomainToDomainMappingProfile());
            ps.AddProfile(new DomainToDtoMappingProfile());
            ps.AddProfile(new DtoToDomainMappingProfile());
        });
    }
}