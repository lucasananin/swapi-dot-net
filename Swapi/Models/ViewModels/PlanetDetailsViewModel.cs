namespace Swapi.Models.ViewModels;

public class PlanetDetailsViewModel : ResourceDetailsViewModel
{
    public string Name { get; init; } = string.Empty;
    public string Population { get; init; } = string.Empty;
    public string Terrain { get; init; } = string.Empty;
    public string Climate { get; init; } = string.Empty;
    public string Gravity { get; init; } = string.Empty;
}