using Drinks.Nick09155.DTO;

namespace Drinks.Nick09155;

using Spectre.Console;

public class Helpers
{
    internal static void DisplayTable(List<DrinkDetailDto> drinkDetails)
    {
        Console.Clear();
        var table = new Table
        {
            Title = new TableTitle("Drink Details", "white")
        };;
        table.AddColumn("ID#");
        table.AddColumn(new TableColumn("Name").Centered());
        table.AddColumn(new TableColumn("Category").Centered());
        table.AddColumn(new TableColumn("Alcohol").Centered());
        table.AddColumn(new TableColumn("Glass").Centered());
        table.AddColumn(new TableColumn("Ingredients").Centered());
        
        foreach (var drinkDetail in drinkDetails)
        {
            var ingredients = drinkDetail.GetIngredients;
            var ingredientsText = string.Join(", ", ingredients);
            table.AddRow($"{drinkDetail.IdDrink}", $"[green]{drinkDetail.StrDrink}[/]",$"[yellow]{drinkDetail.StrCategory}[/]", $"[red]{drinkDetail.StrAlcoholic}[/]", $"[violet]{drinkDetail.StrGlass}[/]", $"[blue]{ingredientsText}[/]");
        }

        AnsiConsole.Write(table);
    }
    
    internal static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}