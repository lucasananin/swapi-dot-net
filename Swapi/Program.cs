using Swapi.Services;
using Swapi.Services.People;
using Swapi.Services.Planets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var swapiLink = "https://swapi.info/api/";
builder.Services.AddHttpClient<ISwapiService, SwapiService>(client =>
{
    client.BaseAddress = new Uri(swapiLink);
});
builder.Services.AddHttpClient<IPersonService, PersonService>(client =>
{
    client.BaseAddress = new Uri(swapiLink);
});
builder.Services.AddHttpClient<IPlanetService, PlanetService>(client =>
{
    client.BaseAddress = new Uri(swapiLink);
});
builder.Services.AddScoped<IResourceDetailsService, ResourceDetailsService>();

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
