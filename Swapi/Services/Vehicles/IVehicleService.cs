using Swapi.Models.ViewModels;

namespace Swapi.Services.Vehicles;

public interface IVehicleService
{
    Task<VehicleDetailsViewModel> GetByIdAsync(int id);
}