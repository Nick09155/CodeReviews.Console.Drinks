using System.Text.Json;
using System.Text.Json.Serialization;

namespace Drinks.Nick09155.DTO;

public class DrinkDetailDto
{
    public int IdDrink { get; set; }
    public string StrDrink { get; set; }
    public string StrCategory { get; set; }
    public string StrGlass { get; set; }
    public string StrAlcoholic { get; set; }
    
    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtensionData { get; set; }

    public List<string> GetIngredients
    {
        get
        {
            var ingredients = new List<string>();
            for (int i = 1; i <= 15; i++)
            {
                if (ExtensionData.TryGetValue($"strIngredient{i}", out var ingredientElement) && !string.IsNullOrWhiteSpace(ingredientElement.GetString()))
                {
                    string ingredient = ingredientElement.GetString();
                    string measure = "";
                    if (ExtensionData.TryGetValue($"strMeasure{i}", out var measureElement) &&
                        measureElement.ValueKind == JsonValueKind.String)
                    {
                        measure = measureElement.GetString() ?? "";
                    }
                    ingredients.Add($"{ingredient}: {measure.Trim()}");
                }
            }
            return ingredients;
        }
    }
}

public class ListDrinkDetailDto
{
    public List<DrinkDetailDto> drinks { get; set; }
}