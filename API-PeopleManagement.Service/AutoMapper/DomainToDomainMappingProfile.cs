using API_PeopleManagement.Domain.Commands;
using API_PeopleManagement.Domain.Commands.ChangeRecordDto;
using API_PeopleManagement.Domain.Commands.Employee;
using API_PeopleManagement.Domain.Commands.EmployeePosition;
using API_PeopleManagement.Domain.Commands.Position;
using API_PeopleManagement.Domain.Commands.Unit;
using API_PeopleManagement.Domain.Entities;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class DomainToDomainMappingProfile : Profile
{
    public DomainToDomainMappingProfile()
    {
        CreateMap<InsertEmployeeCommand, Employees>();
        CreateMap<InsertPositionCommand, Domain.Entities.Positions>();
        CreateMap<InsertUnitCommand, Domain.Entities.Unit>();
        CreateMap<InsertEmployeePositionCommand, EmployeePosition>();
        CreateMap<InsertChangeRecordCommand, Domain.Entities.ChangeRecord>();
    }
}