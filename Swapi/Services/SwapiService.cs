using System.Text.Json;
using Swapi.Constants;
using Swapi.Models;
using Swapi.Models.Api;
using Swapi.Models.Services;
using Swapi.Models.ViewModels;

namespace Swapi.Services;

public class SwapiService(
    HttpClient httpClient,
    ILogger<SwapiService> logger) : ISwapiService
{
    public async Task<ResourceListResult> GetResourceAsync(string resource, string? search = null, int page = 1)
    {
        try
        {
            var stream = await httpClient.GetStreamAsync(resource);
            var list = new List<ResourceItem>();

            if (resource == "films")
            {
                var films = await JsonSerializer.DeserializeAsync<List<TitledApiResource>>(stream);
                list = films?.Select(
                   f => new ResourceItem
                   {
                       Id = ExtractId(f.Url),
                       DisplayName = f.Title,
                       Url = f.Url
                   }).ToList() ?? [];
            }
            else
            {
                var resources = await JsonSerializer.DeserializeAsync<List<NamedApiResource>>(stream);
                list = resources?.Select(
                   r => new ResourceItem
                   {
                       Id = ExtractId(r.Url),
                       DisplayName = r.Name,
                       Url = r.Url
                   }).ToList() ?? [];
            }

            ApplySearchFilter(ref list, search);

            // page = Math.Max(page, 1);
            var totalPages = (int)Math.Ceiling(list.Count / (double)Paging.DEFAULT_PAGE_SIZE);
            var clampedCurrentPage = list.Count > 0 ? Math.Clamp(page, 1, totalPages) : 1;

            var totalItems = list.Count;
            var pagedItems = list.Skip((clampedCurrentPage - 1) * Paging.DEFAULT_PAGE_SIZE).Take(Paging.DEFAULT_PAGE_SIZE).ToList();

            return new ResourceListResult
            {
                Items = pagedItems,

                Pagination = new PaginationViewModel
                {
                    CurrentPage = clampedCurrentPage,
                    PageSize = Paging.DEFAULT_PAGE_SIZE,
                    TotalItems = totalItems
                }
            };
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(
                ex,
                "Unable to retrieve resource list for {Resource}",
                resource);

            return null;
        }
    }

    private static void ApplySearchFilter(ref List<ResourceItem> list, string search)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            list = [.. list
                        .Where(item =>
                            item.DisplayName.Contains(
                                search,
                                StringComparison.OrdinalIgnoreCase))];
        }
    }

    public async Task<PersonDetailsViewModel?> GetPersonAsync(int id)
    {
        var person = await httpClient.GetFromJsonAsync<PersonApiModel>($"people/{id}");

        if (person is null)
            return null;

        return new PersonDetailsViewModel
        {
            Name = person.Name,
            Height = person.Height,
            Mass = person.Mass,
            BirthYear = person.BirthYear,
            Gender = person.Gender
        };
    }

    public Task<string> GetResourceDisplayNameAsync(string resource)
    {
        var displayName = resource switch
        {
            "people" => "Characters",
            "planets" => "Planets",
            "films" => "Films",
            "species" => "Species",
            "starships" => "Starships",
            "vehicles" => "Vehicles",
            _ => resource
        };

        return Task.FromResult(displayName);
    }

    private static int ExtractId(string url)
    {
        var trimmed = url.TrimEnd('/');
        var lastSegment = trimmed.Split('/').Last();
        return int.Parse(lastSegment);
    }
}