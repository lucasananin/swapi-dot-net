using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class StarshipApiModel
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; init; } = string.Empty;

    [JsonPropertyName("cost_in_credits")]
    public string CostInCredits { get; init; } = string.Empty;

    [JsonPropertyName("passengers")]
    public string Passengers { get; init; } = string.Empty;

    [JsonPropertyName("starship_class")]
    public string StarshipClass { get; init; } = string.Empty;
}