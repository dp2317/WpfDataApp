using WpfDataApp.Data;

namespace WpfDataApp.Services;

public interface IPokemonRepository
{
    Task InsertAllAsync(IEnumerable<PokemonEntity> pokemons);
    Task<List<PokemonEntity>> GetAllAsync();
    Task ClearAsync();
}
