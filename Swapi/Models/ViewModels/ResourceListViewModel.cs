namespace Swapi.Models.ViewModels;

class ResourceListViewModel
{
    public string DisplayName { get; init; } = string.Empty;
    // public List<ResourceItem> Items { get; init; } = [];
    
    public string Resource { get; init; } = string.Empty;
    public string? Search { get; set; }
    public IReadOnlyList<ResourceItem> Items { get; init; } = [];
}