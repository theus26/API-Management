using API_PeopleManagement.Domain.Commands;
using API_PeopleManagement.Domain.Entities;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class DomainToDomainMappingProfile : Profile
{
    public DomainToDomainMappingProfile()
    {
        CreateMap<InsertEmployeeCommand, Employees>();
    }
}