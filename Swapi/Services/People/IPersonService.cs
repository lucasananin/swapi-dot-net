using Swapi.Models.ViewModels;

namespace Swapi.Services.People;

public interface IPersonService
{
    Task<PersonDetailsViewModel?> GetByIdAsync(int id);
}