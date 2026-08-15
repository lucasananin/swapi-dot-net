namespace Swapi.Models.ViewModels;

public class PersonDetailsViewModel : ResourceDetailsViewModel
{
    public string Name { get; init; } = "";
    public string Height { get; init; } = "";
    public string Mass { get; init; } = "";
    public string BirthYear { get; init; } = "";
    public string Gender { get; init; } = "";
}