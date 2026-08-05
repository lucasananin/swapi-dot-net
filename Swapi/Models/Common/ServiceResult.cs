namespace Swapi.Models;

public class ServiceResult<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public string? ErrorMessage { get; init; }

    public static ServiceResult<T> Ok(T data)
    {
        return new() { Success = true, Data = data };
    }

    public static ServiceResult<T> Failure(string message)
    {
        return new() { Success = false, ErrorMessage = message };
    }
}