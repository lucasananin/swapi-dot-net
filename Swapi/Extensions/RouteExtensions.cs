namespace Swapi.Extensions;

public static class RouteExtensions
{
    public static WebApplication MapSwapiRoutes(this WebApplication app)
    {
        app.MapControllerRoute(
            name: "favorites",
            pattern: "resources/favorites",
            defaults: new
            {
                controller = "Resources",
                action = "Favorites"
            });

        app.MapControllerRoute(
            name: "toggle-favorite",
            pattern: "resources/{resource}/{id}/favorite",
            defaults: new
            {
                controller = "Resources",
                action = "ToggleFavorite"
            });

        app.MapControllerRoute(
            name: "resource-details",
            pattern: "resources/{resource}/{id:int}",
            defaults: new
            {
                controller = "Resources",
                action = "Details"
            });

        app.MapControllerRoute(
            name: "resources",
            pattern: "resources/{resource}",
            defaults: new
            {
                controller = "Resources",
                action = "Index"
            });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        return app;
    }
}