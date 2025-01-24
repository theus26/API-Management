namespace API_PeopleManagement.Domain.Entities;

public class Unit : BaseEntity
{
    public string NameUnit { get; set; }
    public Guid EmployeeId { get; set; } 
    public virtual Employees Employees { get; set; } 
}