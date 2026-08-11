namespace Swapi.Models.ViewModels;

public class FavoritesViewModel
{
    public IReadOnlyList<FavoriteItemViewModel> Items { get; init; } = [];
}