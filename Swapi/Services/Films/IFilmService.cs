using Swapi.Models.ViewModels;

namespace Swapi.Services.Films;

public interface IFilmService
{
    Task<FilmDetailsViewModel> GetByIdAsync(int id);
}