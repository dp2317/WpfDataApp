using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfDataApp.Data;
using WpfDataApp.Services;

namespace WpfDataApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly PokemonApiService _api;
    private readonly IPokemonRepository _repo;

    public ObservableCollection<PokemonEntity> Items { get; } = new();

    public MainViewModel(PokemonApiService api, IPokemonRepository repo)
    {
        _api = api;
        _repo = repo;
    }

    [RelayCommand]
    public async Task FetchDataAsync()
    {
        // 1) Download data from API
        var apiData = await _api.GetPokemonsAsync();

        // 2) Clear old database data
        await _repo.ClearAsync();

        // 3) Save new data in DB
        await _repo.InsertAllAsync(
            apiData.Select(p => new PokemonEntity { Name = p.name })
        );

        // 4) Load data back from DB and show on screen
        var dbData = await _repo.GetAllAsync();
        Items.Clear();
        foreach (var pokemon in dbData)
            Items.Add(pokemon);
    }
}
