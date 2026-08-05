using Swapi.Models.ViewModels;

namespace Swapi.Services;

public interface IResourceDetailsService
{
    Task<ResourceDetailsResult> GetDetailsAsync(string resource, int id);
}