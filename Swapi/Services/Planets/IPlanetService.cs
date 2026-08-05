using Swapi.Models.ViewModels;

namespace Swapi.Services.Planets;

public interface IPlanetService
{
    Task<PlanetDetailsViewModel?> GetByIdAsync(int id);
}