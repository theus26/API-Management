using System.Text.Json.Serialization;

namespace API_PeopleManagement.Domain.Enum;

public enum Roles
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    Admin = 1,
    Agent = 2,
}