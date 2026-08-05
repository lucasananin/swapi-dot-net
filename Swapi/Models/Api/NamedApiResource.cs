using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class NamedApiResource
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
    
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;
}