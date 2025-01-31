using System.Text.Json.Serialization;

namespace API_PeopleManagement.Domain.Enum;

public enum Roles
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    Admin = 1,
    Exec = 2,
    Fin = 3,
}