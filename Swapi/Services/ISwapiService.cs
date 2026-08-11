using Swapi.Models;
using Swapi.Models.Services;
using Swapi.Models.ViewModels;

namespace Swapi.Services;

public interface ISwapiService
{
    Task<string> GetResourceDisplayNameAsync(string resource);
    Task<ResourceListResult> GetResourcesAsync(string resource, string? search = null, int page = 1);
    Task<PersonDetailsViewModel?> GetPersonAsync(int id);
    Task<ResourceItem?> GetResourceAsync(string resource, int id);
}