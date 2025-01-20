using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Entities;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Employees, EmployeeDto>();
        CreateMap<VacationRecord, VacationRecordDto>();
    }
}