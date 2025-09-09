using Drinks.Nick09155.ApiClients;
using Drinks.Nick09155.DTO;

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
    
    public async Task<List<DrinkDto>> GetDrinksByCategory(string category)
    {
        var drinksList = await _drinkApiClient.GetDrinksByCategory(category);
        return drinksList.ToList();
    }

    public async Task<List<DrinkDetailDto>> GetDrinkDetail(string drinkId)
    {
        var drinkDetail = await _drinkApiClient.GetDrinkDetail(drinkId);
        return drinkDetail;
    }

}