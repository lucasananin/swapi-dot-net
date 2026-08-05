using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class TitledApiResource
{
    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;
}