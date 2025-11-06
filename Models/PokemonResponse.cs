namespace WpfDataApp.Models;

public class PokemonResponse
{
    // This matches "results": [ ... ]
    public List<PokemonItem> results { get; set; } = new();
}

// This matches each item inside the results list
public class PokemonItem
{
    public string name { get; set; } = "";
    public string url { get; set; } = "";
}
