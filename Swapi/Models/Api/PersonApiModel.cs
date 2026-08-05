using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class PersonApiModel
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = "";

    [JsonPropertyName("height")]
    public string Height { get; init; } = "";

    [JsonPropertyName("mass")]
    public string Mass { get; init; } = "";

    [JsonPropertyName("birth_year")]
    public string BirthYear { get; init; } = "";

    [JsonPropertyName("gender")]
    public string Gender { get; init; } = "";
}