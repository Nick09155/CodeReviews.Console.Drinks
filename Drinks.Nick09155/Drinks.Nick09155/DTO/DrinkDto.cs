namespace Drinks.Nick09155.DTO;

public class DrinkDto
{
    public string strDrink { get; set; }
    public string idDrink { get; set; }
}

public class ListDrinkDto
{
    public List<DrinkDto> drinks { get; set; }
}