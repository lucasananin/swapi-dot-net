using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class SpecieApiModel
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("classification")]
    public string Classification { get; init; } = string.Empty;

    [JsonPropertyName("average_height")]
    public string AverageHeight { get; init; } = string.Empty;

    [JsonPropertyName("average_lifespan")]
    public string AverageLifespan { get; init; } = string.Empty;

    [JsonPropertyName("language")]
    public string Language { get; init; } = string.Empty;
}