using System.Net.Http.Headers;
using System.Text.Json;
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json")
);
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static async Task<Pokemon> ProcessPokemonAsync(HttpClient client, string url)
{
    await using Stream stream =
    await client.GetStreamAsync(url);
    Pokemon? Result =
        await JsonSerializer.DeserializeAsync<Pokemon>(stream);
    return Result;
}

Pokemon OnePoke = await ProcessPokemonAsync(client, "https://pokeapi.co/api/v2/pokemon/bulbasaur");
foreach (PokeTypes t in OnePoke.Types)
{
    Console.WriteLine($" - {t.Type.Name}");
}