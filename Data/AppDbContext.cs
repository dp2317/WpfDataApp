using Microsoft.EntityFrameworkCore;

namespace WpfDataApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<PokemonEntity> Pokemon => Set<PokemonEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
