namespace API_PeopleManagement.Domain.Commands.ChangeRecordDto;

public class InsertChangeRecordCommand
{
    public DateTime DateAndTimeOfChange { get; set; }
    public string? ChangedField { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public string? ChangedBy { get; set; }
    public Guid UserId { get; set; }
}