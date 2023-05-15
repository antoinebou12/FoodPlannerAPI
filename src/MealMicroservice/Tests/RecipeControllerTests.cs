using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MealMicroservice.Controllers;
using MealMicroservice.Models;
using MealMicroservice.Data;

public class MealControllerTests
{

    [Fact]
    public void GetIngredients_ReturnsCorrectType()
    {
        // Arrange
        var mockRepo = new Mock<IRecipeRepository>();
        mockRepo.Setup(repo => repo.GetIngredients(1))
            .Returns(GetTestIngredients());
        var controller = new RecipeController(mockRepo.Object);

        // Act
        var result = controller.GetIngredients(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Ingredient>>>(result);
        var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
        var ingredients = Assert.IsAssignableFrom<IEnumerable<Ingredient>>(returnValue.Value);
        Assert.Equal(3, ingredients.Count());
    }

    private List<Ingredient> GetTestIngredients()
    {
        var ingredients = new List<Ingredient>
        {
            new Ingredient { Id = 1, Name = "Ingredient1" },
            new Ingredient { Id = 2, Name = "Ingredient2" },
            new Ingredient { Id = 3, Name = "Ingredient3" }
        };

        return ingredients;
    }

    [Fact]
    public void GetIngredient_ReturnsCorrectType()
    {
        // Arrange
        var mockRepo = new Mock<IRecipeRepository>();
        mockRepo.Setup(repo => repo.GetIngredient(1, 1))
            .Returns(GetTestIngredient());
        var controller = new RecipeController(mockRepo.Object);

        // Act
        var result = controller.GetIngredient(1, 1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Ingredient>>(result);
        var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
        var ingredient = Assert.IsAssignableFrom<Ingredient>(returnValue.Value);
        Assert.Equal("Ingredient1", ingredient.Name);
    }

    private Ingredient GetTestIngredient()
    {
        return new Ingredient { Id = 1, Name = "Ingredient1" };
    }

    [Fact]
    public void GetIngredient_ReturnsNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IRecipeRepository>();
        mockRepo.Setup(repo => repo.GetIngredient(1, 1))
            .Returns(GetTestIngredient());
        var controller = new RecipeController(mockRepo.Object);

        // Act
        var result = controller.GetIngredient(1, 2);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Ingredient>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    [Fact]
    public void CreateIngredient_ReturnsCorrectType()
    {
        // Arrange
        var mockRepo = new Mock<IRecipeRepository>();
        mockRepo.Setup(repo => repo.CreateIngredient(1, GetTestIngredient()));
        var controller = new RecipeController(mockRepo.Object);

        // Act
        var result = controller.CreateIngredient(1, GetTestIngredient());

        // Assert
        var actionResult = Assert.IsType<ActionResult<Ingredient>>(result);
        var returnValue = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        var ingredient = Assert.IsAssignableFrom<Ingredient>(returnValue.Value);
        Assert.Equal("Ingredient1", ingredient.Name);
    }
}
