using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Enum;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace API_PeopleManagement.Service.Vacation;

public class VacationService(IBaseRepository<VacationRecord> vacationRepository, IMapper mapper, IValidator<VacationRecord> employeeValidator ) : IVacationService
{
    public VacationRecordDto CreateEmployee(CreateVacationRecordDto vacationRecordDto)
    {
        var holidaysExists = vacationRepository.GetAll().FirstOrDefault(x=> x.EmployeesId == vacationRecordDto.EmployeesId);
        if (holidaysExists?.VacationStatus is VacationStatus.Pending or VacationStatus.InProgress)
        {
            throw new ValidationException("vacation already exists");
        }
        var vacation = mapper.Map<VacationRecord>(vacationRecordDto);
        Validate(vacation);
        var createdEmployee = vacationRepository.Create(vacation);
        return mapper.Map<VacationRecordDto>(createdEmployee);
    }
    
    private void Validate(VacationRecord vacationRecord)
    {
        var validationResult = employeeValidator.Validate(vacationRecord);

        if (validationResult.IsValid) return;
        var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
        throw new ValidationException($"Validation failed: {errors}");
    }
}