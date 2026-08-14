using System.Text.Json.Serialization;

namespace Swapi.Models.Api;

public class FilmApiModel
{
    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;
    
    [JsonPropertyName("director")]
    public string Director { get; init; } = string.Empty;
    
    [JsonPropertyName("producer")]
    public string Producer { get; init; } = string.Empty;
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; init; } = string.Empty;
}