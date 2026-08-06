namespace Swapi.Models.ViewModels;

public class PaginationViewModel
{
    public int CurrentPage { get; init; }
    public int PageSize { get; init; }
    public int TotalItems { get; init; }

    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    public bool HasNext => CurrentPage < TotalPages;
    public bool HasPrevious => CurrentPage > 1;
}