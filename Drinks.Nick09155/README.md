# [Drinks Info](https://thecsharpacademy.com/project/15/drinks)


## Requirements
- :white_check_mark: You were hired by restaurant to create a solution for their drinks menu.
- :white_check_mark: Their drinks menu is provided by an external company. All the data about the drinks is in the companies database, accessible through an API.
- :white_check_mark: Your job is to create a system that allows the restaurant employee to pull data from any drink in the database.
- :white_check_mark: You don't need SQL here, as you won't be operating the database. All you need is to create an user-friendly way to present the data to the users (the restaurant employees).
- :white_check_mark: When the users open the application, they should be presented with the Drinks Category Menu and invited to choose a category. Then they'll have the chance to choose a drink and see information about it.
- :white_check_mark: When the users visualise the drink detail, there shouldn't be any properties with empty values.


# Tech Stack

- .NET 9
- Spectre Console
- HttpClient

# Features

- Connects to an external API to fetch a comprehensive list of drink categories and detailed drink information.
- Presents an interactive console menu where users can first select a drink category.
- Allows users to choose a specific drink from the selected category to view its details.
- Displays the chosen drink's information in a formatted table, including a consolidated list of ingredients and measures, while hiding any empty or null properties.