using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging.Abstractions;
using Swapi.Services;

namespace Swapi.Tests;

public class SwapiServiceTests
{
    [Theory]
    [InlineData("people", "Characters")]
    [InlineData("planets", "Planets")]
    [InlineData("films", "Films")]
    [InlineData("species", "Species")]
    [InlineData("starships", "Starships")]
    [InlineData("vehicles", "Vehicles")]
    public async Task GetResourceDisplayNameAsync_ReturnsExpectedName(string resource, string expected)
    {
        // Arrange
        var service = CreateService();

        // Act
        var result = await service.GetResourceDisplayNameAsync(resource);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetResourceDisplayNameAsync_UnknownResource_ReturnsOriginalValue()
    {
        var service = CreateService();

        var result = await service.GetResourceDisplayNameAsync("droids");

        Assert.Equal("droids", result);
    }

    // [Fact]
    // public async Task GetResourceDisplayNameAsync_People_ReturnsCharacters()
    // {
    //     // Arrange
    //     var service = CreateService();

    //     // Act
    //     var result = await service.GetResourceDisplayNameAsync("people");

    //     // Assert
    //     Assert.Equal("Characters", result);
    // }

    private static SwapiService CreateService()
    {
        var httpClient = new HttpClient();

        var memoryCache = new MemoryCache(
            new MemoryCacheOptions());

        var logger = NullLogger<SwapiService>.Instance;

        return new SwapiService(httpClient, memoryCache, logger);
    }
}
