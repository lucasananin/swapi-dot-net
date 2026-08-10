using Microsoft.EntityFrameworkCore;
using Swapi.Data;
using Swapi.Models.Favorites;

namespace Swapi.Services;

public class FavoriteService(AppDbContext dbContext) : IFavoriteService
{
    public async Task<IReadOnlyList<Favorite>> GetAllAsync()
    {
        return await dbContext.Favorites
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> IsFavoriteAsync(string resourceType, int resourceId)
    {
        return await dbContext.Favorites
            .AsNoTracking()
            .AnyAsync(favorite =>
                favorite.ResourceType == resourceType &&
                favorite.ResourceId == resourceId);
    }

    public async Task AddAsync(string resourceType, int resourceId)
    {
        var exists = await dbContext.Favorites
            .AnyAsync(favorite =>
                favorite.ResourceType == resourceType &&
                favorite.ResourceId == resourceId);

        if (exists) return;

        var favorite = new Favorite
        {
            ResourceType = resourceType,
            ResourceId = resourceId
        };

        dbContext.Favorites.Add(favorite);

        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(string resourceType, int resourceId)
    {
        var favorite = await dbContext.Favorites
            .FirstOrDefaultAsync(favorite =>
                favorite.ResourceType == resourceType &&
                favorite.ResourceId == resourceId);

        if (favorite is null) return;

        dbContext.Favorites.Remove(favorite);
        await dbContext.SaveChangesAsync();
    }
}