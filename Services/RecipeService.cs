using System.Text.Json;

namespace RecipeFinder.Api.Services;

public class RecipeService
{
    private readonly HttpClient _httpClient;

    public RecipeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<JsonElement?> SearchRecipesAsync(string query)
    {
        var url = $"https://www.themealdb.com/api/json/v1/1/search.php?s={Uri.EscapeDataString(query)}";

        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(json);

        return document.RootElement.Clone();
    }
}
