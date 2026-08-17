namespace Swapi.Models.ViewModels;

public class StarshipDetailsViewModel : ResourceDetailsViewModel
{
    public string Name { get; init; } = string.Empty;
    public string Manufacturer { get; init; } = string.Empty;
    public string CostInCredits { get; init; } = string.Empty;
    public string Passengers { get; init; } = string.Empty;
    public string StarshipClass { get; init; } = string.Empty;
}