using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.DTO.vacations;

public class VacationRecordDto
{
    public Guid EmployeeId { get; set; }
    public DateTime StartedIn { get; set; }
    public DateTime EndIn { get; set; }
    public VacationStatus VacationStatus { get; set; }
}