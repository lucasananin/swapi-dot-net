using Swapi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();
services.AddMemoryCache();
services.AddSwapiServices();
services.AddOtherServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

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

app.Run();
