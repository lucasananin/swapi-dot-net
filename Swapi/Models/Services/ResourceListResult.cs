using Swapi.Models.ViewModels;

namespace Swapi.Models.Services;

public class ResourceListResult
{
    public required IReadOnlyList<ResourceItem> Items { get; init; }

    public required PaginationViewModel Pagination { get; init; }
}