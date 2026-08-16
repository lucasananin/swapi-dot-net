namespace Swapi.Models.ViewModels;

public class VehicleDetailsViewModel : ResourceDetailsViewModel
{
    public string Name { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public string Manufacturer { get; init; } = string.Empty;
    public string CostInCredits { get; init; } = string.Empty;
    public string VehicleClass { get; init; } = string.Empty;
}