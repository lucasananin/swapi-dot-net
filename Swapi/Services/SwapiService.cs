using System.Text.Json;
using Swapi.Models;
using Swapi.Models.Api;
using Swapi.Models.ViewModels;

namespace Swapi.Services;

public class SwapiService(
    HttpClient httpClient,
    ILogger<SwapiService> logger) : ISwapiService
{
    public async Task<List<ResourceItem>> GetResourceAsync(string resource, string? search = null)
    {
        // var response = await httpClient.GetAsync(resource);
        // response.EnsureSuccessStatusCode();
        // var stream = await response.Content.ReadAsStreamAsync();
        // var resources = await JsonSerializer.DeserializeAsync<List<ResourceItem>>(stream);
        // return resources ?? [];

        try
        {
            var stream = await httpClient.GetStreamAsync(resource);

            if (resource == "films")
            {
                var films = await JsonSerializer.DeserializeAsync<List<TitledApiResource>>(stream);
                // return films?.Select(
                //     f => new ResourceItem
                //     {
                //         Id = ExtractId(f.Url),
                //         DisplayName = f.Title,
                //         Url = f.Url
                //     }).ToList() ?? [];
                var list = films?.Select(
                    f => new ResourceItem
                    {
                        Id = ExtractId(f.Url),
                        DisplayName = f.Title,
                        Url = f.Url
                    }).ToList() ?? [];

                TrySortSearch(ref list, search);
                // if (!string.IsNullOrWhiteSpace(search))
                // {
                //     list = [.. list
                //         .Where(item =>
                //             item.DisplayName.Contains(
                //                 search,
                //                 StringComparison.OrdinalIgnoreCase))];
                // }
                return list;
            }
            else
            {
                var resources = await JsonSerializer.DeserializeAsync<List<NamedApiResource>>(stream);
                var list = resources?.Select(
                    r => new ResourceItem
                    {
                        Id = ExtractId(r.Url),
                        DisplayName = r.Name,
                        Url = r.Url
                    }).ToList() ?? [];
                TrySortSearch(ref list, search);
                return list;
            }
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(
                ex,
                "Unable to retrieve resource list for {Resource}",
                resource);

            return [];
        }
    }

    private static void TrySortSearch(ref List<ResourceItem> list, string search)
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