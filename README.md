# Assignment: Data Fetch → Save → Display (WPF + SQLite + API)

This application fetches Pokémon data from a public API, stores it in a local SQLite database, and then displays the stored data in the UI.

## Public API Used
PokéAPI  
https://pokeapi.co/api/v2/pokemon?limit=50

## How It Works
1. The user clicks **Fetch Pokémon**.
2. The app downloads Pokémon names from the API.
3. The app saves the Pokémon list into a local SQLite database (`pokemon.db`).
4. It then loads the data back from the database.
5. The Pokémon names are displayed in the UI ListBox.

## Technologies Used
- C# WPF (.NET 8)
- SQLite + Entity Framework Core
- HttpClient (REST API)
- MVVM (CommunityToolkit.Mvvm)
- Dependency Injection (Microsoft.Extensions.Hosting)

## Project Structure
Data/ # Database Models & DbContext
Models/ # JSON Models for API
Services/ # API Service + Repository Pattern
ViewModels/ # MVVM Logic
MainWindow.xaml # UI


## How to Run
1. Open the project in Visual Studio or VS Code.
2. Restore NuGet packages (`dotnet restore` if using terminal).
3. Run the application.
4. Click **Fetch Pokémon** to load and display Pokémon names.
