namespace Swapi.Models.ViewModels;

public class PaginationViewModel
{
    public int CurrentPage { get; init; }
    public int PageSize { get; init; }
    public int TotalItems { get; init; }

    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public bool HasNext => CurrentPage < TotalPages;
    public bool HasPrevious => CurrentPage > 1;

    public string Resource { get; init; } = string.Empty;
    public string? Search { get; set; }

    private const int WindowSize = 5;
    
    public IEnumerable<int> GetVisiblePages()
    {
        var start = Math.Max(1, CurrentPage - WindowSize / 2);
        var end = Math.Min(TotalPages, start + WindowSize - 1);

        if (end - start + 1 < WindowSize)
        {
            start = Math.Max(1, end - WindowSize + 1);
        }

        for (var page = start; page <= end; page++)
        {
            yield return page;
        }
    }
}