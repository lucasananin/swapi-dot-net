namespace Swapi.Models.ViewModels;

public class SpecieDetailsViewModel : ResourceDetailsViewModel
{
    public string Name { get; init; } = string.Empty;
    public string Classification { get; init; } = string.Empty;
    public string AverageHeight { get; init; } = string.Empty;
    public string AverageLifespan { get; init; } = string.Empty;
    public string Language { get; init; } = string.Empty;
}