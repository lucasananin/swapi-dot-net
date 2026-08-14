using Swapi.Models.ViewModels;
using Swapi.Services.Films;
using Swapi.Services.People;
using Swapi.Services.Planets;

namespace Swapi.Services;

public class ResourceDetailsService(
    IPersonService _personService,
    IPlanetService planetService,
    IFilmService filmService) : IResourceDetailsService
{
    public async Task<ResourceDetailsResult> GetDetailsAsync(string resource, int id)
    {
        switch (resource)
        {
            case "people":

                var person = await _personService.GetByIdAsync(id);
                if (person is null) return null;
                return new ResourceDetailsResult
                {
                    ViewName = "PersonDetails",
                    Model = person,
                    PageTitle = person.Name
                };

            case "planets":

                var planet = await planetService.GetByIdAsync(id);
                if (planet is null) return null;
                return new ResourceDetailsResult
                {
                    ViewName = "PlanetDetails",
                    Model = planet,
                    PageTitle = planet.Name
                };

            case "films":
                var film = await filmService.GetByIdAsync(id);
                return new ResourceDetailsResult
                {
                    ViewName = "FilmDetails",
                    Model = film,
                    PageTitle = film.Title,
                };

            default:
                return null;
        }
    }
}