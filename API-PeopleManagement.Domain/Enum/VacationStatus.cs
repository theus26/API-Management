using System.Text.Json.Serialization;

namespace API_PeopleManagement.Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VacationStatus
{
    Pending = 1,
    InProgress = 2,
    Completed = 3
}
