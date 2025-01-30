namespace API_PeopleManagement.Domain.Entities;

public class ChangeRecord : BaseEntity
{
    public DateTime DateAndTimeOfChange { get; set; }
    public string ChangedField { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public string ChangedBy { get; set; }
    public virtual Users Users { get; set; }
    public virtual Guid UserId { get; set; }
    public virtual Employees Employees { get; set; }
    public virtual Guid EmployeesId { get; set; }
}