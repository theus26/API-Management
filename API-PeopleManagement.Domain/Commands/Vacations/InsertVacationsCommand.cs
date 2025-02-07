using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.Commands.Vacations;

public class InsertVacationsCommand
{
    public DateTime StartedIn { get; set; }
    public DateTime EndIn { get; set; }
    public VacationStatus VacationStatus { get; set; }
    public Guid EmployeesId { get; set; }
}