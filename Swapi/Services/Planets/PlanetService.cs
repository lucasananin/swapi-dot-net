using Swapi.Models.Api;
using Swapi.Models.ViewModels;

namespace Swapi.Services.Planets;

public class PlanetService(
    HttpClient httpClient,
    IFavoriteService favoriteService,
    ILogger<PlanetService> logger) : IPlanetService
{
    public async Task<PlanetDetailsViewModel?> GetByIdAsync(int id)
    {
        try
        {
            var _planet = await httpClient.GetFromJsonAsync<PlanetApiModel>($"planets/{id}");

            if (_planet is null)
            {
                logger.LogWarning("SWAPI returned null for Planet {PlanetId}", id);
                return null;
            }

            var isFavorite = await favoriteService.IsFavoriteAsync("planets", id);

            return new PlanetDetailsViewModel
            {
                Id = id,
                IsFavorite = isFavorite,
                Name = _planet.Name,
                Population = _planet.Population,
                Terrain = _planet.Terrain,
                Climate = _planet.Climate,
                Gravity = _planet.Gravity,
            };
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "Unable to retrieve Planet {Planet} from SWAPI.", id);
            throw;
        }
    }
}