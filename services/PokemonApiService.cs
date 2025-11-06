using System.Net.Http;
using System.Net.Http.Json;
using WpfDataApp.Models;

namespace WpfDataApp.Services;

public class PokemonApiService
{
    private readonly HttpClient _http;

    public PokemonApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<PokemonItem>> GetPokemonsAsync()
    {
        // Call the API and read JSON into C# objects
        var response = await _http.GetFromJsonAsync<PokemonResponse>(
            "https://pokeapi.co/api/v2/pokemon?limit=50"
        );

        // If response is null, return an empty list
        return response?.results ?? new List<PokemonItem>();
    }
}
