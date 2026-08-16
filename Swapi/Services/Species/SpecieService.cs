using Swapi.Constants;
using Swapi.Models.Api;
using Swapi.Models.ViewModels;

namespace Swapi.Services.Species;

public class SpecieService(
    HttpClient httpClient,
    IFavoriteService favoriteService) : ISpecieService
{
    public async Task<SpecieDetailsViewModel> GetByIdAsync(int id)
    {
        var specie = await httpClient.GetFromJsonAsync<SpecieApiModel>($"{Resources.SPECIES}/{id}");
        var isFavorite = await favoriteService.IsFavoriteAsync(Resources.SPECIES, id);

        return new SpecieDetailsViewModel
        {
            Id = id,
            IsFavorite = isFavorite,
            Name = specie.Name,
            Classification = specie.Classification,
            AverageHeight = specie.AverageHeight,
            AverageLifespan = specie.AverageLifespan,
            Language = specie.Language,
        };
    }
}