namespace API_PeopleManagement.Domain.Entities;

public class EmployeePosition : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public virtual Employees Employees { get; set; }
    public Guid PositionId { get; set; }
    public virtual Positions Positions { get; set; }
    public DateTime DateCreation { get; set; }
}