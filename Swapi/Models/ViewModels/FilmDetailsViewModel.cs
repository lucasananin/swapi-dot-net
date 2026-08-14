namespace Swapi.Models.ViewModels;

public class FilmDetailsViewModel : ResourceDetailsViewModel
{
    public string Title { get; init; } = string.Empty;
    public string Director { get; init; } = string.Empty;
    public string Producer { get; init; } = string.Empty;
    public string ReleaseDate { get; init; } = string.Empty;
}