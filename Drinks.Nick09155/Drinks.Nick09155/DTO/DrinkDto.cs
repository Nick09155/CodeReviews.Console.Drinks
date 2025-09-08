namespace Drinks.Nick09155.DTO;

public class DrinkDto
{
    public string StrDrink { get; set; }
    public string StrDrinkThumb { get; set; }
    public string IdDrink { get; set; }
}

public class ListDrinkDto
{
    public List<DrinkDto> drinks { get; set; }
}