# Food Planner API

This is a Recipe and Food Planner application built using FastAPI and MongoDB. The application helps users manage recipes, meal plans, inventory at home, and shopping lists based on nutrient information.

## Features

- Create, view, update, and delete recipes with detailed instructions and nutritional information.
- Create, view, update, and delete foods with nutritional information.
- Create, view, update, and delete meal plans containing recipes.
- Manage inventory at home, including food items and their quantities.
- Create, view, update, and delete shopping lists with food items and their locations.

## Installation

1. Clone this repository:

```bash
git clone https://github.com/yourusername/recipe_food_planner.git
```

2. Create a virtual environment and activate it:

```bash
python3 -m venv venv
source venv/bin/activate
```

3. Install the required dependencies:

```bash
pip install -r requirements.txt
```

4. Make sure you have a running instance of MongoDB. Update the `config/settings.py` file with your MongoDB connection settings.

## Running the Application

To start the FastAPI application, run the following command:

```bash
uvicorn app.main:app --reload
```

The application will be available at http://127.0.0.1:8000/. You can access the interactive API documentation at http://127.0.0.1:8000/docs.

## API Endpoints

The application provides the following API endpoints:

- `POST /recipes`: Create a new recipe
- `GET /recipes`: Retrieve all recipes
- `GET /recipes/{recipe_id}`: Retrieve a specific recipe by ID
- `PUT /recipes/{recipe_id}`: Update a specific recipe by ID
- `DELETE /recipes/{recipe_id}`: Delete a specific recipe by ID

... (similar endpoints for foods, meal plans, inventory, and shopping lists)

## License

This project is licensed under the MIT License.
