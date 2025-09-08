using Drinks.Nick09155.ApiClients;
using Drinks.Nick09155.Services;

namespace Drinks.Nick09155;

public class UserMenu
{
    public DrinkApiClient _drinkApiClient;
    private string[] drinkCategories;
    private DrinksService drinksService;
    private string[] drinksByCategory;
    public UserMenu()
    {
        _drinkApiClient = new DrinkApiClient();
        drinksService = new DrinksService();
    }
    
    public async Task GetUserInput()
    {
        bool closeApp = false;
        bool showCategoriesMenu = false;
        bool showDrinksMenu = false;
        Console.WriteLine(showCategoriesMenu);
        while (!closeApp)
        {
            if (showCategoriesMenu)
            {
                GetCategoriesMenuInput();
            }

            if (showDrinksMenu)
            {
                GetDrinksMenuInput();
            }
            string[] mainMenuOptions = {
                "Choose a Drink Category",
                "Close Application"
            };
            int selectedIndex = ShowMenu("\n\nMAIN MENU\nWhat would you like to do?", mainMenuOptions);
            Console.WriteLine(selectedIndex);

            switch (selectedIndex)
            {
                case 0:
                    drinkCategories = await drinksService.GetDrinkCategories();
                    showCategoriesMenu = true;
                    break;
                case 1: // View Study Sessions
                    // _studySessionService.ViewStudySessions();
                    break;
                case 2: // Go To Stack Menu
                    // GetStackInput();
                    break;
                case 3: // Go To Flashcard Menu
                    // GetFlashcardInput();
                    break;
                case 4: // Close Application
                    Console.WriteLine("Goodbye.");
                    closeApp = true;
                    break;
            }
        }
    }
    public void GetCategoriesMenuInput()
    {
        
        while (true)
        {
            Console.Clear();
        int selectedIndex = ShowMenu("\n\nCATEGORIES\nWhat would you like to pick?", drinkCategories);
            
            
            // string userInput = Console.ReadLine();
            switch (selectedIndex)
            {
                case 0:
                    // stackSelected = false;
                    break;
                // case "1":
                //     // stackService.ViewStacks();
                //     break;
                // case "2":
                //     // stackService.AddStack();
                //     break;
                // case "3":
                //     // stackService.RemoveStack();
                //     break;
                default:
                    Console.WriteLine("Invalid Command, try again.");
                    break;
            }
        }
    }
    public async Task GetDrinksMenuInput()
    {
        bool flashcardSelected = true;
        while (true)
        {
            int selectedIndex = ShowMenu("\n\nDRINKS\nWhat would you like to pick?", drinkCategories);
            switch (selectedIndex)
            {
                case 0:
                    drinksByCategory = await drinksService.GetDrinksByCategory(drinksByCategory[selectedIndex]);
                    
                    break;
                // case "1":
                //     // flashcardService.ViewFlashcardsByStack();
                //     break;
                // case "2":
                //     // flashcardService.ViewAllFlashcards();
                //     break;
                // case "3":
                //     // flashcardService.RemoveFlashcard();
                //     break;
                default:
                    Console.WriteLine("Invalid Command, try again.");
                    break;
            }
        }
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

            // Update selectedIndex based on arrow keys.
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