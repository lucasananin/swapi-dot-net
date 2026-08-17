using Swapi.Constants;
using Swapi.Models.Api;
using Swapi.Models.ViewModels;

namespace Swapi.Services.Starships;

public class StarshipService(
    HttpClient httpClient,
    IFavoriteService favoriteService) : IStarshipService
{
    public async Task<StarshipDetailsViewModel> GetByIdAsync(int id)
    {
        var starship = await httpClient.GetFromJsonAsync<StarshipApiModel>($"{Resources.STARSHIPS}/{id}");
        var isFavorite = await favoriteService.IsFavoriteAsync(Resources.STARSHIPS, id);

        return new StarshipDetailsViewModel
        {
            Id = id,
            IsFavorite = isFavorite,
            Name = starship.Name,
            Manufacturer = starship.Manufacturer,
            CostInCredits = starship.CostInCredits,
            Passengers = starship.Passengers,
            StarshipClass = starship.StarshipClass,
        };
    }
}