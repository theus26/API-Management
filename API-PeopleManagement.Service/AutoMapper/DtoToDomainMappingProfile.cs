using API_PeopleManagement.Domain.Commands;
using API_PeopleManagement.Domain.Commands.ChangeRecordDto;
using API_PeopleManagement.Domain.Commands.Employee;
using API_PeopleManagement.Domain.Commands.Position;
using API_PeopleManagement.Domain.Commands.Unit;
using API_PeopleManagement.Domain.Commands.Vacations;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.employee;
using API_PeopleManagement.Domain.DTO.position;
using API_PeopleManagement.Domain.DTO.vacations;
using API_PeopleManagement.Domain.Entities;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<CreateEmployeesDto, InsertEmployeeCommand>();
        CreateMap<CreatePositionDto, InsertPositionCommand>();
        CreateMap<UpdatePositionDto, UpdatePositionCommand>().ReverseMap();
        CreateMap<ChangeRecordDto, Domain.Entities.ChangeRecord>();
        CreateMap<PositionDto, Domain.Entities.Positions>().ReverseMap();
        CreateMap<CreateUnitDto, InsertUnitCommand>();
        CreateMap<ChangeRecordDto, InsertChangeRecordCommand>();
        CreateMap<CreateVacationRecordDto, InsertVacationsCommand>();
    }
}