# Recipe and Food Planner API

This is a Recipe and Food Planner application built using Blazor WebAssembly, C#, and MongoDB. The application helps users manage recipes, meal plans, inventory at home, and shopping lists based on nutrient information.

![DB](http://www.plantuml.com/plantuml/dpng/dLDDZzCm4BtdLmmzWdO5TrGj4bfHQIc8vOxSU9eEEBQnnokgYlzE9w6E7H4gxIdpyTxCi_ro5ra5JhrfNl01UuITIUW3MMwQrgWOuGksv15E3S2hJxllsF96mpVIaZ_o6Ta14niiSesn3UIPd9Ng0qL-kx5TG4reUGsKurZq8uVK2aS0EHaGsyI19DlOlGDRPdd0k7iDhBg1ix6C7GRm0VrNwh6ijSxzcDSYXYUoP-xloyadoN0gJcVLIBmtJZ7yJCeoyR4094jSJibdWLEraD5lKx_3i71rUKHz_DEql5N61S8uLNnmZ6IdmbvnYGyxTpZgeBWaxKb4v3IcJfMfqvJwISszSthP3lc2Sjegniw5uxM7p0i-eZAVZRB_NlBWMcNUAqOOh2jHNKQhSr6C8UFMqACoiTu1fueeXW0z1XDxjFyQml2jtF64bbqulkCFhiS5iJ92Bcp3sAzX_pSgnboQ8r-o0NNTOFMPVtaAIgvIqcdwuy5vVwQ8ZlyeB66ZKgfLbe3dgXMqA1QLO2IeJ5wsg_yjiWkuhJsbA1eKxlWyi7gpWfiRMBs-lNsvAdxSfNx-9MS0-LGURKJMSZTRjLuWvQ4tgu_BcfbrQb1sH7C9olLIQwfNhSdpXwgmLuVD0UMRD7TeTUhD7m00)

## Features

- Create, view, update, and delete recipes with detailed instructions and nutritional information.
- Create, view, update, and delete foods with nutritional information.
- Create, view, update, and delete meal plans containing recipes.
- Manage inventory at home, including food items and their quantities.
- Create, view, update, and delete shopping lists with food items and their locations.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (optional, but recommended)
- A running instance of MongoDB. Update the `RecipeFoodPlanner.Server/appsettings.json` file with your MongoDB connection settings.

## Getting Started

1. Clone this repository:

```bash
git clone https://github.com/yourusername/recipe_food_planner.git
```

2. Open the `RecipeFoodPlanner.sln` solution file in Visual Studio 2022 or your preferred IDE.

3. Set the `RecipeFoodPlanner.Server` project as the startup project.

4. Run the server-side application using the "Start" button in Visual Studio or by running the following command in the terminal:

```bash
dotnet run --project RecipeFoodPlanner.Server
```

5. Open a new terminal and navigate to the `RecipeFoodPlanner.Client` project directory. Start the client-side Blazor WebAssembly application using the following command:

```bash
dotnet run
```

6. The application will be available at http://localhost:5000. You can browse the recipes, foods, meal plans, inventory, and shopping lists using the navigation menu.

## Project Structure

- `RecipeFoodPlanner.Client`: Client-side Blazor WebAssembly project, containing Razor components for the user interface and services for API communication.
- `RecipeFoodPlanner.Server`: Server-side ASP.NET Core project, providing the API for the client-side Blazor application.
- `RecipeFoodPlanner.Server/Controllers`: API controllers for recipes, foods, meal plans, inventory, and shopping lists.
- `RecipeFoodPlanner.Server/Data`: Data context and repository classes for MongoDB.
- `RecipeFoodPlanner.Server/Models`: Data models for recipes, foods, meal plans, inventory, and shopping lists.

## Contributing

Please feel free to submit issues, fork the repository and send pull requests!

## License

This project is licensed under the MIT License.
