using Microsoft.EntityFrameworkCore;
using WpfDataApp.Data;

namespace WpfDataApp.Services;

public class PokemonRepository : IPokemonRepository
{
    private readonly AppDbContext _db;

    public PokemonRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task InsertAllAsync(IEnumerable<PokemonEntity> pokemons)
    {
        await _db.Pokemon.AddRangeAsync(pokemons);
        await _db.SaveChangesAsync();
    }

    public Task<List<PokemonEntity>> GetAllAsync() =>
        _db.Pokemon.AsNoTracking().ToListAsync();

    public async Task ClearAsync()
    {
        _db.Pokemon.RemoveRange(_db.Pokemon);
        await _db.SaveChangesAsync();
    }
}
