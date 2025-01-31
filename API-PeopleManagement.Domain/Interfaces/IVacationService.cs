using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.vacations;
using API_PeopleManagement.Domain.Events;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IVacationService
{
    Task<EventInserted> CreateVacation(CreateVacationRecordDto vacationRecordDto);
}