using Drinks.Nick09155.ApiClients;

namespace Drinks.Nick09155.Services;

public class DrinksService
{
    private readonly DrinkApiClient _drinkApiClient;

    public DrinksService()
    {
        _drinkApiClient = new DrinkApiClient();
    }

    public async Task<string[]> GetDrinkCategories()
    {
        var categories = await _drinkApiClient.GetDrinkCategories();
        return categories.Select(c => c.strCategory).ToArray();
    }
    
    public async Task<string[]> GetDrinksByCategory(string category)
    {
        var drinksList = await _drinkApiClient.GetDrinksByCategory(category);
        return drinksList.Select(c => c.StrDrink).ToArray();
    }

}