using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class VehicleApiModel
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("model")]
    public string Model { get; init; } = string.Empty;

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; init; } = string.Empty;

    [JsonPropertyName("cost_in_credits")]
    public string CostInCredits { get; init; } = string.Empty;

    [JsonPropertyName("vehicle_class")]
    public string VehicleClass { get; init; } = string.Empty;
}