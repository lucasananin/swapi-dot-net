using Microsoft.EntityFrameworkCore;
using Swapi.Data;
using Swapi.Services;
using Swapi.Services.Films;
using Swapi.Services.People;
using Swapi.Services.Planets;
using Swapi.Services.Species;
using Swapi.Services.Starships;
using Swapi.Services.Vehicles;

namespace Swapi.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddSwapiServices(this IServiceCollection services)
    {
        const string SWAPI_LINK = "https://swapi.info/api/";

        services.AddHttpClient<ISwapiService, SwapiService>(client =>
        {
            client.BaseAddress = new Uri(SWAPI_LINK);
        });
        services.AddHttpClient<IPersonService, PersonService>(client =>
        {
            client.BaseAddress = new Uri(SWAPI_LINK);
        });
        services.AddHttpClient<IPlanetService, PlanetService>(client =>
        {
            client.BaseAddress = new Uri(SWAPI_LINK);
        });
        services.AddHttpClient<IFilmService, FilmService>(client =>
        {
            client.BaseAddress = new Uri(SWAPI_LINK);
        });
        services.AddHttpClient<ISpecieService, SpecieService>(client =>
        {
            client.BaseAddress = new Uri(SWAPI_LINK);
        });
        services.AddHttpClient<IVehicleService, VehicleService>(client =>
        {
            client.BaseAddress = new Uri(SWAPI_LINK);
        });
        services.AddHttpClient<IStarshipService, StarshipService>(client =>
        {
            client.BaseAddress = new Uri(SWAPI_LINK);
        });

        return services;
    }

    public static IServiceCollection AddOtherServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IResourceDetailsService, ResourceDetailsService>();
        services.AddScoped<IFavoriteService, FavoriteService>();

        return services;
    }
}