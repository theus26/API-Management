using API_PeopleManagement.Domain.DTO;

namespace API_PeopleManagement.Domain.Interfaces;

public interface IVacationService
{
    VacationRecordDto CreateVacation(CreateVacationRecordDto vacationRecordDto);
}