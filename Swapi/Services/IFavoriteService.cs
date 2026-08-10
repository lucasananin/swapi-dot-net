using Swapi.Models.Favorites;

namespace Swapi.Services;

public interface IFavoriteService
{
    Task<IReadOnlyList<Favorite>> GetAllAsync();

    Task<bool> IsFavoriteAsync(string resourceType, int resourceId);

    Task AddAsync(string resourceType, int resourceId);

    Task RemoveAsync(string resourceType, int resourceId);
}