# Food Planner

![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?logo=.net&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-5C2D91?logo=.net&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-5C2D91?logo=.net&logoColor=white)

This is a Recipe and Food Planner application built using .NET 6 and Docker. The application is structured as a collection of microservices and helps users manage recipes, meal plans, home inventory, and shopping lists based on nutrient information.

![DB](http://www.plantuml.com/plantuml/dpng/fLHHRnCn37w_Ns7w2De4xwZQ49gej0t4U4TfubxDSicH-0PLjV_El6kF-AfeI3oTy_cpVPzZvoApIJnqldd5M-mGrdx0Fb7WfkcDlJSjmk8hMkeHRiYcc34zaCK5x1i0wqtES70B0F3cy_e7Mbuv-4vkHEuuKMY1YJqgn66sYNgc64RycZA_NuKseICCl0IQxAmOcTDW9Kueq-70kHquaPnNOHCXbASYoVWFIs3J7k9MWR7517t2_Xjrg54Ru_qf-joE81dWiPawybS2x9NYO8u9hdmq33y74vXufqX38DRv2i6md_q0OtyxT6jCrTPAgiVYEgzYTDNB56VjAfKC1LZ3sCQqU_a2b2vDt9UTiSR7H9XBh4-HaK89RGphgBIEsvrBXdNeXgH31P27rcWWEXgwasRTeF7mnPjGxPWmX53lsdMqndyqZ23RncBD7HXS0SjyIjebT6ZyRBZ40VjP0fbCSADHPXbtSmb9lfXFvAt20mQEQLULDp4k-LFiAci-rPFnMJ5sIzWShDdV7md7F786uVxhMkYs_Uuf6PaWEPwekzl6lfTO-RUgmYDBI2_8AwcZJ3gLg4Z_ALLYHAv817ymT3b5qSzDvfZmThwiXhBNo2zSPsADzTjT9clyfNC9yoWHOAhwWRolDqkDv06AmzeZSEIdd5qS0i-2SzasTxpBSO1XyMu1PsUmU7j-_dfHlAyr__HUQe9yzAlJIFlgtccvTG61dtqpV2pMp7P6awOLQ8v6MLwmHasa3fuFb-9MabK9QdQgLPyikUtc0eCREly7)

## Features

- [ ] Create, view, update, and delete recipes with detailed instructions and nutritional information.
- [ ] Create, view, update, and delete foods with nutritional information.
- [ ] Create, view, update, and delete meal plans containing recipes.
- [ ] Manage inventory at home, including food items and their quantities.
- [ ] Create, view, update, and delete shopping lists with food items and their locations.
- [ ] Monitor nutritional information for recipes, foods, and meal plans.
- [ ] Monitor food item quantities in inventory and shopping lists.
- [ ] Generate shopping lists based on meal plans and inventory.
- [ ] Generate meal plans based on inventory and shopping lists.
- [ ] Generate meal plans based on nutritional goals.
- [ ] Generate shopping lists based on nutritional goals.
- [ ] Generate meal plans based on food preferences.
- [ ] Generate shopping lists based on food preferences.
- [ ] Generate meal plans based on food allergies.
- [ ] Generate shopping lists based on food allergies.

- Monitoring Microservices
  - [ ] Logging
  - [ ] Health Checks
  - [ ] Metrics
  - [ ] Tracing


## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (optional, but recommended)
- A running instance of MongoDB. Update the `RecipeFoodPlanner.Server/appsettings.json` file with your MongoDB connection settings.

## Getting Started

1. Clone this repository:

```bash
https://github.com/antoinebou12/FoodPlannerAPI
cd src
docker-compose up --build -d
# The application will be available at http://localhost:5000. You can browse the recipes, foods, meal plans, inventory, and shopping lists using the navigation menu.
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

- `RecipeMicroservice`: This microservice handles the creation, retrieval, updating, and deletion of recipes.
- `FoodMicroservice`: This microservice is responsible for managing foods and their nutritional information.
- `MealPlanMicroservice`: This service manages meal plans containing recipes.
- `InventoryMicroservice`: This microservice takes care of managing the inventory at home, including food items and their quantities.
- `ShoppingListMicroservice`: This service is responsible for managing shopping lists with food items and their locations.
- `APIGateway`: This is the entry point for all client requests. It forwards requests to appropriate microservices.
- `Tests`: Contains unit tests for each microservice.

# Monitoring and Stats
This application uses Application Insights for monitoring and Prometheus + Grafana for dashboard stats. Health checks are built-in for each microservice and Docker stats can be used for monitoring resource usage.

## Contributing

Please feel free to submit issues, fork the repository and send pull requests!

## License

This project is licensed under the MIT License.
