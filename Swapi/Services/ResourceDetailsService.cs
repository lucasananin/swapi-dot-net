using Swapi.Constants;
using Swapi.Models.ViewModels;
using Swapi.Services.Films;
using Swapi.Services.People;
using Swapi.Services.Planets;
using Swapi.Services.Species;
using Swapi.Services.Vehicles;

namespace Swapi.Services;

public class ResourceDetailsService(
    IPersonService _personService,
    IPlanetService planetService,
    IFilmService filmService,
    ISpecieService specieService,
    IVehicleService vehicleService) : IResourceDetailsService
{
    public async Task<ResourceDetailsResult> GetDetailsAsync(string resource, int id)
    {
        switch (resource)
        {
            case Resources.PEOPLE:

                var person = await _personService.GetByIdAsync(id);
                if (person is null) return null;
                return new ResourceDetailsResult
                {
                    ViewName = "PersonDetails",
                    Model = person,
                    PageTitle = person.Name
                };

            case Resources.PLANETS:

                var planet = await planetService.GetByIdAsync(id);
                if (planet is null) return null;
                return new ResourceDetailsResult
                {
                    ViewName = "PlanetDetails",
                    Model = planet,
                    PageTitle = planet.Name
                };

            case Resources.FILMS:
                var film = await filmService.GetByIdAsync(id);
                return new ResourceDetailsResult
                {
                    ViewName = "FilmDetails",
                    Model = film,
                    PageTitle = film.Title,
                };

            case Resources.SPECIES:
                var specie = await specieService.GetByIdAsync(id);
                return new ResourceDetailsResult
                {
                    ViewName = "SpecieDetails",
                    Model = specie,
                    PageTitle = specie.Name,
                };

            case Resources.VEHICLES:
                var vehicle = await vehicleService.GetByIdAsync(id);
                return new ResourceDetailsResult
                {
                    ViewName = "VehicleDetails",
                    Model = vehicle,
                    PageTitle = vehicle.Name,
                };

            default:
                return null;
        }
    }
}