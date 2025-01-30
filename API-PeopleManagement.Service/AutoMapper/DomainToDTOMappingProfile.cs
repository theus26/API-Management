using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.DTO.employeePosition;
using API_PeopleManagement.Domain.DTO.position;
using API_PeopleManagement.Domain.DTO.vacations;
using API_PeopleManagement.Domain.Entities;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Employees, EmployeeDto>();
        CreateMap<Employees, ListEmployeeDto>();
        CreateMap<EmployeePosition, EmployeePositionDto>();
        CreateMap<VacationRecord, VacationRecordDto>();
        CreateMap<Unit, UnitDto>();
    }
}