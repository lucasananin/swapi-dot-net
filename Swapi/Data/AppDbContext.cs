using Microsoft.EntityFrameworkCore;
using Swapi.Models.Favorites;

namespace Swapi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Favorite> Favorites => Set<Favorite>();
}