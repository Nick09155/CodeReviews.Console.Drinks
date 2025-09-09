namespace Drinks.Nick09155.DTO;

public class DrinkDetailDto
{
    public int IdDrink { get; set; }
    public string StrDrink { get; set; }
    public string StrCategory { get; set; }
    public string StrAlcoholic { get; set; }
}

public class ListDrinkDetailDto
{
    public List<DrinkDetailDto> drinks { get; set; }
}