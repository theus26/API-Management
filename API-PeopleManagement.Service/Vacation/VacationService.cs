using API_PeopleManagement.Domain.Commands.Vacations;
using API_PeopleManagement.Domain.DTO.vacations;
using API_PeopleManagement.Domain.Entities;
using API_PeopleManagement.Domain.Enum;
using API_PeopleManagement.Domain.Events;
using API_PeopleManagement.Domain.Interfaces;
using AutoMapper;
using FluentValidation;

namespace API_PeopleManagement.Service.Vacation;

public class VacationService(IBaseRepository<VacationRecord> vacationRepository, IMapper mapper, IValidator<VacationRecord> employeeValidator,  VacationCommandHandler vacationCommandHandler) : IVacationService
{
    public async Task<EventInserted> CreateVacation(CreateVacationRecordDto vacationRecordDto)
    {
        var holidaysExists = vacationRepository.GetAll().FirstOrDefault(x => x.EmployeesId == vacationRecordDto.EmployeesId);
        if (holidaysExists?.VacationStatus is VacationStatus.Pending or VacationStatus.InProgress)
        {
            throw new ValidationException("vacation already exists");
        }

        if (vacationRecordDto.VacationStatus is VacationStatus.Completed)
        {
            throw new ValidationException("It is not possible to register holidays with full status");
        }
        
        var vacationCommand = mapper.Map<InsertVacationsCommand>(vacationRecordDto);
        ValidateIntervalbetweenDatas(vacationCommand.StartedIn, vacationCommand.EndIn);
        return await vacationCommandHandler.HandleCommand(vacationCommand);
    }
    
    private static void ValidateIntervalbetweenDatas(DateTime startDate, DateTime endDate)
    {
        if (endDate <= startDate)
        {
            throw new ValidationException("The end date must be after the start date.");
        }
        var daysDifference = (endDate - startDate).TotalDays;
        if (daysDifference is < 10 or > 30)
        {
            throw new ValidationException($"The vacation period must be between 10 and 30 days, selected period - {daysDifference} days.");
        }
    }
}