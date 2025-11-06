using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfDataApp.Data;
using WpfDataApp.Services;
using WpfDataApp.ViewModels;

namespace WpfDataApp;

public partial class App : Application
{
    public static IHost AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Database
                services.AddDbContext<AppDbContext>(o => o.UseSqlite("Data Source=pokemon.db"));

                // Services
                services.AddHttpClient<PokemonApiService>();
                services.AddScoped<IPokemonRepository, PokemonRepository>();

                // ViewModel & Main Window
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost.StartAsync();

        var db = AppHost.Services.GetRequiredService<AppDbContext>();
        await db.Database.EnsureCreatedAsync();

        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
