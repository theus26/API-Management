using API_PeopleManagement.Domain.DTO;
using API_PeopleManagement.Domain.DTO.vacations;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IVacationService
{
    VacationRecordDto CreateVacation(CreateVacationRecordDto vacationRecordDto);
}