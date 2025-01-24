using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.vacations;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Enum;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace API_PeopleManagement.Service.Vacation;

public class VacationService(IBaseRepository<VacationRecord> vacationRepository, IMapper mapper, IValidator<VacationRecord> employeeValidator ) : IVacationService
{
    public VacationRecordDto CreateVacation(CreateVacationRecordDto vacationRecordDto)
    {
        var holidaysExists = vacationRepository.GetAll().FirstOrDefault(x=> x.EmployeesId == vacationRecordDto.EmployeesId);
        if (holidaysExists?.VacationStatus is VacationStatus.Pending or VacationStatus.InProgress)
        {
            throw new ValidationException("vacation already exists");
        }

        if (vacationRecordDto.VacationStatus is VacationStatus.Completed)
        {
            throw new ValidationException("It is not possible to register holidays with full status");
        }
        
        var vacation = mapper.Map<VacationRecord>(vacationRecordDto);
        Validate(vacation);
        var createdEmployee = vacationRepository.Create(vacation);
        return mapper.Map<VacationRecordDto>(createdEmployee);
    }
    
    private void Validate(VacationRecord vacationRecord)
    {
        //ValidateIntervalbetweenDatas(vacationRecord.startedIn, vacationRecord.endIn);
        var validationResult = employeeValidator.Validate(vacationRecord);
        if (validationResult.IsValid) return;
        var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
        throw new ValidationException($"Validation failed: {errors}");
    }

    private static void ValidateIntervalbetweenDatas(DateTime startDate, DateTime endDate)
    {
        if (endDate <= startDate)
        {
            throw new ArgumentException("The end date must be after the start date.");
        }
        var daysDifference = (endDate - startDate).TotalDays;
        if (daysDifference is < 10 or > 30)
        {
            throw new ArgumentException($"The vacation period must be between 10 and 30 days, selected period - {daysDifference} days.");
        }
    }
}