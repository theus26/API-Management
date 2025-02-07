namespace API_PeopleManagement.Domain.Commands.Employee;

public class DeleteEmployeeCommand(Guid id)
{
    public Guid Id { get; set; } = id;
}