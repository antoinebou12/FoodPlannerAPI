# Food Planner

![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?logo=.net&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-512BD4?logo=blazor&logoColor=white)

This is a Recipe and Food Planner application built using Blazor WebAssembly, C#. The application helps users manage recipes, meal plans, inventory at home, and shopping lists based on nutrient information.

![DB](http://www.plantuml.com/plantuml/dpng/dLJVRzGm37xlNs7k4RG9tj5fGsZYf34Guntb6b_Fa2OXSGQd4_yxTRjBazFA99vgV_xym-xNNaLMWLDlcXUynnvXQnBwG9QRfZKgHlY2BNc4OmFmwjFsExQyqV2DjFZtF30xO6A3XQynje4yaxE2tbBajnlR1TI4bjT0sOv5F798hUG88JiZuovn8F4sTkV0bbukCFLU0wjkpDbOnWu3-83-A_LOOgrpFywnYE61x93xvxJvF38SY-sicX9lZ5CCFvEoJ7me2CaIbrNoBd2i6ZBwkzHlCIoSBfUerp_EpLjbN22CC-A3OoGx0pl59JzitVwWW-8oQKSoH7PZwbJfEasfdwUvSKuloo4VABkjOknSE3pt8dE3ZwZCPwFiqqrktR3rUyK8etJ5gc6qEeCY32ctXXwLYNKFE5Q98WZGZqREdkI_XZ0-AtKyeELXhsl-u7fS65PAoC4sZFqQTezMKUOKdFB56rdF2wpU-RUdeEIKuixLx_VE-o55vlZ7X2LjcfJgAIl2VquhR9bOfWGZHYNoAbn-Rv5TmBjQKugYAVrVk8t49UBtXqYjCjTQ1up5Ak_8cATFKObW15pQ6WHsFDJfNR9SfSNoA5ewJ6A1rPiLN5p0wlNbvSjLyHjPYkSVH4sGH_tjDtAavMZ-SEe60e-nCtngrfm9kIPbVJOdesmlM5Dfh4u-bqt5NIwsJCWAMUmwMFA6cokqElNcBm00)

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

- src: This is the root directory where all the source code is stored.

- Application: This contains the application's business logic. It includes configurations, enums, exceptions, extensions, features (like Brands, Dashboards, Documents), interfaces, mappings (for AutoMapper), models, requests and responses, serialization settings, specifications for queries, and validators.

- Client: This contains the client-side code written in Blazor. It includes models, pages (or views), resources, and shared components. This project is responsible for user interface and user interactions.

- Client.Infrastructure: This includes the client-side infrastructure code, like managers that handle business logic, routes for API endpoints, and settings for the application.

- Domain: This includes the domain entities and contracts for the application. Domain entities are plain classes that incorporate both behavior and data format.

- Infrastructure: This includes code related to database configurations, contexts, and repositories. It also contains migrations that are used for database versioning and update, models, resources, services, and specifications.

- Infrastructure.Shared: This shared infrastructure project includes common services that are used across the application.

- Server: This contains server-side code, which is mainly responsible for handling HTTP requests and responses. It includes Controllers, Dockerfile (for containerization), Extensions, Files, Filters, Hubs (for SignalR communication), Localization, Managers, Middlewares, Resources, Services, and Settings.

- Shared: This includes code that is shared between the client and the server. It contains constants, managers, models, settings, and wrappers that are used across the entire solution.

## Contributing

Please feel free to submit issues, fork the repository and send pull requests!

## License

This project is licensed under the MIT License.
