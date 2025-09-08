using Drinks.Nick09155.ApiClients;

namespace Drinks.Nick09155;

public class UserMenu
{
    public DrinkApiClient _drinkApiClient;
    public UserMenu()
    {
        _drinkApiClient = new DrinkApiClient();
    }
    
    public void GetUserInput()
    {
        bool closeApp = false;
        while (!closeApp)
        {
            string[] mainMenuOptions = {
                "Choose a Drink Category",
                "Close Application"
            };
            int selectedIndex = ShowMenu("\n\nMAIN MENU\nWhat would you like to do?", mainMenuOptions);
            Console.WriteLine(selectedIndex);

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Getting Drink Categories...");
                    var categories = _drinkApiClient.GetDrinkCategories().Result;
                    foreach (var category in categories)
                    {
                        Console.WriteLine(category.StrCategory);
                    }

                    Console.ReadKey();
                    // _studySessionService.StartStudySession();
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
    // public void GetStackInput()
    // {
    //     bool stackSelected = true;
    //     while (stackSelected)
    //     {
    //         Console.WriteLine("\n\nSTACK MENU");
    //         Console.WriteLine("\nType 0 to Go back to Main Menu.");
    //         Console.WriteLine("Type 1 to View Available Stacks.");
    //         Console.WriteLine("Type 2 to Create a New Stack.");
    //         Console.WriteLine("Type 3 to Delete a Stack.");
    //         Console.WriteLine("------------------------------------------\n");
    //         
    //         string userInput = Console.ReadLine();
    //         switch (userInput)
    //         {
    //             case "0":
    //                 stackSelected = false;
    //                 break;
    //             case "1":
    //                 // stackService.ViewStacks();
    //                 break;
    //             case "2":
    //                 // stackService.AddStack();
    //                 break;
    //             case "3":
    //                 // stackService.RemoveStack();
    //                 break;
    //             default:
    //                 Console.WriteLine("Invalid Command, try again.");
    //                 break;
    //         }
    //     }
    // }
    // public void GetFlashcardInput()
    // {
    //     bool flashcardSelected = true;
    //     while (flashcardSelected)
    //     {
    //         Console.WriteLine("\n\nFLASHCARD MENU");
    //         Console.WriteLine("\nType 0 to Go Back to Main Menu.");
    //         Console.WriteLine("Type 1 to Select Flashcard Stack.");
    //         Console.WriteLine("Type 2 to View All Flashcards.");
    //         Console.WriteLine("Type 3 to Delete a Flashcard.");
    //         Console.WriteLine("------------------------------------------\n");
    //         
    //         string userInput = Console.ReadLine();
    //         switch (userInput)
    //         {
    //             case "0":
    //                 flashcardSelected = false;
    //                 break;
    //             case "1":
    //                 // flashcardService.ViewFlashcardsByStack();
    //                 break;
    //             case "2":
    //                 // flashcardService.ViewAllFlashcards();
    //                 break;
    //             case "3":
    //                 // flashcardService.RemoveFlashcard();
    //                 break;
    //             default:
    //                 Console.WriteLine("Invalid Command, try again.");
    //                 break;
    //         }
    //     }
    // }
    //
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