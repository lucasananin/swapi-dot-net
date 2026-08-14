using Swapi.Models.Api;
using Swapi.Models.ViewModels;

namespace Swapi.Services.Films;

public class FilmService(
    HttpClient httpClient,
    IFavoriteService favoriteService) : IFilmService
{
    public async Task<FilmDetailsViewModel> GetByIdAsync(int id)
    {
        var film = await httpClient.GetFromJsonAsync<FilmApiModel>($"films/{id}");
        var isFavorite = await favoriteService.IsFavoriteAsync("films", id);

        return new FilmDetailsViewModel
        {
            Id = id,
            IsFavorite = isFavorite,
            Title = film.Title,
            Director = film.Director,
            Producer = film.Producer,
            ReleaseDate = film.ReleaseDate,
        };
    }
}