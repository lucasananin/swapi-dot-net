using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class PlanetApiModel
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("population")]
    public string Population { get; init; } = string.Empty;

    [JsonPropertyName("terrain")]
    public string Terrain { get; init; } = string.Empty;

    [JsonPropertyName("climate")]
    public string Climate { get; init; } = string.Empty;

    [JsonPropertyName("gravity")]
    public string Gravity { get; init; } = string.Empty;
}