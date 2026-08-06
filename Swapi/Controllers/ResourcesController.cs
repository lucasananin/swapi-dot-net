using Microsoft.AspNetCore.Mvc;
using Swapi.Models.ViewModels;
using Swapi.Services;

namespace Swapi.Controllers;

public class ResourcesController(
    ISwapiService _swapiService,
    IResourceDetailsService _resourceDetailsService) : Controller
{
    public async Task<IActionResult> Index(string resource, string? search)
    {
        string _displayName = await _swapiService.GetResourceDisplayNameAsync(resource);
        var resources = await _swapiService.GetResourceAsync(resource, search);

        var viewModel = new ResourceListViewModel
        {
            DisplayName = _displayName,
            Resource = resource,
            Search = search,
            Items = resources,
            Pagination = new()
            {
                CurrentPage = 1,
                PageSize = 10,
                TotalItems = resources.Count,
            }
        };

        ViewData["Title"] = _displayName;
        return View(viewModel);
    }

    public async Task<IActionResult> Details(string resource, int id)
    {
        // return Content(
        //     $"Resource: {resource}\nId: {id}",
        //     "text/plain");
        // if (resource != "people") return NotFound();

        var result = await _resourceDetailsService.GetDetailsAsync(resource, id);
        if (result is null) return NotFound();

        ViewData["Title"] = result.PageTitle;
        return View(result.ViewName, result.Model);
        // return View("PersonDetails", result.Model);
    }
}