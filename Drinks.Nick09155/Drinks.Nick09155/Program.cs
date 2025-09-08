// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using Drinks.Nick09155;
using Drinks.Nick09155.DTO;

HttpClient client = new HttpClient();
// Create a new instance of UserMenu and call GetUserInput
// var results = await client.GetFromJsonAsync<DrinkCategoryResponse>("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
// Console.WriteLine(results);

UserMenu userMenu = new UserMenu();

userMenu.GetUserInput();