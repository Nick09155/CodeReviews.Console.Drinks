using Drinks.Nick09155.DTO;
using Drinks.Nick09155.Services;

namespace Drinks.Nick09155;

public class UserMenu
{
    private string[] drinkCategories;
    private DrinksService drinksService;
    private string[] drinksByCategory;
    private List<DrinkDto> fullDrinksByCategory;
    private bool showCategoriesMenu = false;
    private bool showDrinksMenu = false;
    public UserMenu()
    {
        drinksService = new DrinksService();
    }
    
    public async Task GetUserInput()
    {
        bool closeApp = false;
        Console.WriteLine(showCategoriesMenu);
        while (!closeApp)
        {
            if (showCategoriesMenu)
            {
               await GetCategoriesMenuInput();
            }

            if (showDrinksMenu)
            {
                await GetDrinksMenuInput();
            }
            
            string[] mainMenuOptions = {
                "Choose a Drink Category",
                "Close Application"
            };
            
            int selectedIndex = ShowMenu("\n\nMAIN MENU\nWhat would you like to do?", mainMenuOptions);
            switch (selectedIndex)
            {
                case 0:
                    drinkCategories = await drinksService.GetDrinkCategories();
                    showCategoriesMenu = true;
                    break;
                case 1:
                    Console.WriteLine("Goodbye.");
                    closeApp = true;
                    break;
            }
        }
    }
    public async Task GetCategoriesMenuInput()
    {
            Console.Clear();
            int selectedIndex = ShowMenu("\n\nCATEGORIES\nWhat would you like to pick?", drinkCategories);
            
            showDrinksMenu = true;
            showCategoriesMenu = false;
            fullDrinksByCategory = await drinksService.GetDrinksByCategory(drinkCategories[selectedIndex]);
            drinksByCategory = fullDrinksByCategory.Select(x => x.strDrink).ToArray();
    }

    public async Task GetDrinksMenuInput()
    {
        int selectedIndex = ShowMenu("\n\nDRINKS\nWhat drink would you like more info for?", drinksByCategory);
        string drinkId = fullDrinksByCategory[selectedIndex].idDrink;
        var drinkDetails = await drinksService.GetDrinkDetail(drinkId);
        Helpers.DisplayTable(drinkDetails);
        Helpers.PressAnyKeyToContinue();
    }

    private int ShowMenu(string title, string[] options)
    {
        int selectedIndex = 0;
        ConsoleKey keyPressed;

        do
        {
            Console.Clear();
            Console.WriteLine(title);

            for (int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
                string prefix;

                if (i == selectedIndex)
                {
                    prefix = ">>";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{prefix} {currentOption}");
            }
            Console.ResetColor();

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length)
                {
                    selectedIndex = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter);

        return selectedIndex;
    }
}