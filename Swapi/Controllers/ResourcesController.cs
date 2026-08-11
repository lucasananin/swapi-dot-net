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
        var result = await _swapiService.GetResourceAsync(resource, search, page);

        var clampedCurrentPage = result.Items.Count > 0 ? Math.Clamp(result.Pagination.CurrentPage, 1, result.Pagination.TotalPages) : 1;
        var viewModel = new ResourceListViewModel
        {
            DisplayName = _displayName,
            Resource = resource,
            Search = search,
            Items = result.Items,
            Pagination = new()
            {
                // CurrentPage = result.Pagination.CurrentPage,
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleFavorite(int id)
    {
        var isFavorite = await favoriteService.IsFavoriteAsync("people", id);

        if (isFavorite)
        {
            await favoriteService.RemoveAsync("people", id);
        }
        else
        {
            await favoriteService.AddAsync("people", id);
        }

        // return RedirectToAction(nameof(Details), new { id });
        return RedirectToAction(nameof(Details), new
        {
            resource = "people",
            id,
        });
    }
}