// using System.Text.Json.Serialization;

namespace Swapi.Models;

public class ResourceItem
{
    // [JsonPropertyName("name")]
    // public string Name { get; set; } = string.Empty;
    public int Id { get; init; }
    public string DisplayName { get; init; } = string.Empty;
    public string Url { get; init; } = string.Empty;
}