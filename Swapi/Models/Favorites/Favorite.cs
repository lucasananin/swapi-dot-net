namespace Swapi.Models.Favorites;

public class Favorite
{
    public int Id { get; init; }
    public string? ResourceType { get; init; }
    public int ResourceId { get; init; }
}