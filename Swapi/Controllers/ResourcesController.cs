using Microsoft.AspNetCore.Mvc;
using Swapi.Models.ViewModels;
using Swapi.Services;

namespace Swapi.Controllers;

public class ResourcesController(
    ISwapiService _swapiService,
    IFavoriteService favoriteService,
    IResourceDetailsService _resourceDetailsService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string resource, string? search, int page = 1)
    {
        string _displayName = await _swapiService.GetResourceDisplayNameAsync(resource);
        var result = await _swapiService.GetResourcesAsync(resource, search, page);

        var clampedCurrentPage = result.Items.Count > 0 ? Math.Clamp(result.Pagination.CurrentPage, 1, result.Pagination.TotalPages) : 1;
        var viewModel = new ResourceListViewModel
        {
            DisplayName = _displayName,
            Resource = resource,
            Search = search,
            Items = result.Items,
            Pagination = new()
            {
                CurrentPage = clampedCurrentPage,
                PageSize = result.Pagination.PageSize,
                TotalItems = result.Pagination.TotalItems,
                Resource = resource,
                Search = search
            }
        };

        ViewData["Title"] = _displayName;
        return View(viewModel);
    }

    public async Task<IActionResult> Details(string resource, int id)
    {
        var result = await _resourceDetailsService.GetDetailsAsync(resource, id);
        if (result is null) return NotFound();

        ViewData["Title"] = result.PageTitle;
        return View(result.ViewName, result.Model);
    }

    // [HttpPost("resources/{resource}/{id}/favorite")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleFavorite(string resource, int id)
    {
        var isFavorite = await favoriteService.IsFavoriteAsync(resource, id);

        if (isFavorite)
            await favoriteService.RemoveAsync(resource, id);
        else
            await favoriteService.AddAsync(resource, id);

        return RedirectToAction(nameof(Details), new
        {
            resource,
            id,
        });
    }

    [HttpGet]
    public async Task<IActionResult> Favorites()
    {
        var favorites = await favoriteService.GetAllAsync();

        var items = new List<FavoriteItemViewModel>();

        foreach (var favorite in favorites)
        {
            var resource = await _swapiService.GetResourceAsync(favorite.ResourceType, favorite.ResourceId);

            if (resource is null) continue;

            items.Add(new FavoriteItemViewModel
            {
                Id = favorite.ResourceId,
                Resource = favorite.ResourceType,
                Name = resource.DisplayName
            });
        }

        var model = new FavoritesViewModel
        {
            Items = items
        };

        return View(model);
    }
}