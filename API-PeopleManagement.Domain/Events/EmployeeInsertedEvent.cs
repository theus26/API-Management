namespace API_PeopleManagement.Domain.Events;

public class EmployeeInsertedEvent(Guid id, bool isSucess)
{
    public Guid Id { get; set; } = id;
    public bool IsSucess { get; set; } = isSucess;
}