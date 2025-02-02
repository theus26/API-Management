using System.Text.Json.Serialization;

namespace API_PeopleManagement.Domain.Enum;

public enum Roles
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    Adm = 1,
    Exe = 2,
    Fin = 3,
}