namespace Swapi.Models.ViewModels;

public class ResourceDetailsResult
{
    public required string ViewName { get; init; }
    public required object Model { get; init; }
    public required string PageTitle { get; init; }
}