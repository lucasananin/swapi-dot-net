using Swapi.Models.ViewModels;

namespace Swapi.Services.Starships;

public interface IStarshipService
{
    Task<StarshipDetailsViewModel> GetByIdAsync(int id);
}