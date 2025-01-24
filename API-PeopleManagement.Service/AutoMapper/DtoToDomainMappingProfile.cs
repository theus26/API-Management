using API_PeopleManagement.Domain.Commands;
using API_PeopleManagement.Domain.Commands.Employee;
using API_PeopleManagement.Domain.Commands.Position;
using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.position;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<CreateEmployeesDto, InsertEmployeeCommand>();
        CreateMap<ChangeRecordDto, Domain.Entities.ChangeRecord>();
        CreateMap<CreatePositionDto, InsertPositionCommand>();
        CreateMap<PositionDto, Domain.Entities.Positions>().ReverseMap();
        
    }
}