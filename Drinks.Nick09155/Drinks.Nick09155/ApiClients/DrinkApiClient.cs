using System.Net.Http.Json;
using Drinks.Nick09155.DTO;

namespace Drinks.Nick09155.ApiClients;

public class DrinkApiClient
{
    private readonly HttpClient _httpClient;

    public DrinkApiClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<DrinkDto>> GetDrinks()
    {
        return await _httpClient.GetFromJsonAsync<List<DrinkDto>>("https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita");
    }
    
    public async Task<List<DrinkCategoryDto>> GetDrinkCategories()
    {
        // DrinkCategoryResponse categories = null;
        DrinkCategoryResponse response = null;
        try
        {
            response = await _httpClient.GetFromJsonAsync<DrinkCategoryResponse>("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
        } catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while fetching drink categories: {ex.Message}");
            // return new List<DrinkCategoryDto>();
        }
        Console.WriteLine("HEllO");
        // List<DrinkCategoryDto> categories2 = categories.drinks;
        // return categories;
        return response?.drinks ?? new List<DrinkCategoryDto>();
    }
}