using API_PeopleManagement.Domain.Enum;

namespace API_PeopleManagement.Domain.Entities;

public class VacationRecord : BaseEntity
{
    public DateTime StartedIn { get; set; }
    public DateTime EndIn { get; set; }
    public VacationStatus VacationStatus { get; set; }
    public virtual Employees Employees { get; set; }
    public Guid EmployeesId { get; set; }
}
