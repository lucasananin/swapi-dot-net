using Swapi.Models.Api;
using Swapi.Models.ViewModels;

namespace Swapi.Services.Vehicles;

public class VehicleService(
    HttpClient httpClient,
    IFavoriteService favoriteService) : IVehicleService
{
    public async Task<VehicleDetailsViewModel> GetByIdAsync(int id)
    {
        var vehicle = await httpClient.GetFromJsonAsync<VehicleApiModel>($"vehicles/{id}");
        var isFavorite = await favoriteService.IsFavoriteAsync("vehicles", id);

        return new VehicleDetailsViewModel
        {
            Id = id,
            IsFavorite = isFavorite,
            Name = vehicle.Name,
            Model = vehicle.Model,
            Manufacturer = vehicle.Manufacturer,
            CostInCredits = vehicle.CostInCredits,
            VehicleClass = vehicle.VehicleClass,
        };
    }
}