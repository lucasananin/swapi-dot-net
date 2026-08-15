using Swapi.Models.ViewModels;

namespace Swapi.Services.Species;

public interface ISpecieService
{
    Task<SpecieDetailsViewModel> GetByIdAsync(int id);
}