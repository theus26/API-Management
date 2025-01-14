using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Entities;
using AutoMapper;

namespace API_PeopleManagement.Service.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateEmployeesDto, Employees>();
        CreateMap<Employees, EmployeeDto>().ReverseMap();
        
        CreateMap<CreateVacationRecordDto, VacationRecord>();
        CreateMap<VacationRecord, VacationRecordDto>().ReverseMap();

        CreateMap<ChangeRecordDto, Domain.Entities.ChangeRecord>().ReverseMap();
        
        
    }
}