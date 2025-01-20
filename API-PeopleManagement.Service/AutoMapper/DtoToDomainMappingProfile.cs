using API_PeopleManagement.Domain.Commands;
using API_PeopleManagement.Domain.DTO;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<CreateEmployeesDto, InsertEmployeeCommand>();
    }
}