using Swapi.Models;
using Swapi.Models.ViewModels;

namespace Swapi.Services;

public interface ISwapiService
{
    Task<string> GetResourceDisplayNameAsync(string resource);
    Task<List<ResourceItem>> GetResourceAsync(string resource, string? search = null);
    Task<PersonDetailsViewModel?> GetPersonAsync(int id);
}