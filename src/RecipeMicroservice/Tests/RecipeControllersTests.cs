// using Xunit;
// using Moq;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using RecipeMicroservice.Controllers;
// // using RecipeMicroservice.Models;
// // using RecipeMicroservice.Data;

// public class RecipeControllerTests
// {

// [Fact]
//     public void GetRecipes_ReturnsCorrectType()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.GetRecipes())
//             .Returns(GetTestRecipes());
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.GetRecipes();

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<IEnumerable<Recipe>>>(result);
//         var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
//         var recipes = Assert.IsAssignableFrom<IEnumerable<Recipe>>(returnValue.Value);
//         Assert.Equal(3, recipes.Count());
//     }

//     private List<Recipe> GetTestRecipes()
//     {
//         var recipes = new List<Recipe>
//         {
//             new Recipe { Id = 1, Title = "Recipe1" },
//             new Recipe { Id = 2, Title = "Recipe2" },
//             new Recipe { Id = 3, Title = "Recipe3" }
//         };

//         return recipes;
//     }

//     [Fact]
//     public void GetRecipe_ReturnsCorrectType()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.GetRecipe(1))
//             .Returns(GetTestRecipe());
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.GetRecipe(1);

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<Recipe>>(result);
//         var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
//         var recipe = Assert.IsAssignableFrom<Recipe>(returnValue.Value);
//         Assert.Equal("Recipe1", recipe.Title);
//     }

//     private Recipe GetTestRecipe()
//     {
//         return new Recipe { Id = 1, Title = "Recipe1" };
//     }

//     [Fact]
//     public void GetRecipe_ReturnsNotFound()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.GetRecipe(1))
//             .Returns(GetTestRecipe());
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.GetRecipe(2);

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<Recipe>>(result);
//         Assert.IsType<NotFoundResult>(actionResult.Result);
//     }

//     [Fact]
//     public void CreateRecipe_ReturnsCorrectType()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.CreateRecipe(GetTestRecipe()));
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.CreateRecipe(GetTestRecipe());

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<Recipe>>(result);
//         var returnValue = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
//         var recipe = Assert.IsAssignableFrom<Recipe>(returnValue.Value);
//         Assert.Equal("Recipe1", recipe.Title);
//     }

//     [Fact]
//     public void UpdateRecipe_ReturnsCorrectType()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.UpdateRecipe(1, GetTestRecipe()));
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.UpdateRecipe(1, GetTestRecipe());

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<Recipe>>(result);
//         Assert.IsType<NoContentResult>(actionResult.Result);
//     }

//     [Fact]
//     public void UpdateRecipe_ReturnsBadRequest()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.UpdateRecipe(1, GetTestRecipe()));
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.UpdateRecipe(2, GetTestRecipe());

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<Recipe>>(result);
//         Assert.IsType<BadRequestResult>(actionResult.Result);
//     }

//     [Fact]
//     public void DeleteRecipe_ReturnsCorrectType()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.DeleteRecipe(1));
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.DeleteRecipe(1);

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<Recipe>>(result);
//         Assert.IsType<NoContentResult>(actionResult.Result);
//     }

//     [Fact]
//     public void DeleteRecipe_ReturnsBadRequest()
//     {
//         // Arrange
//         var mockRepo = new Mock<IRecipeRepository>();
//         mockRepo.Setup(repo => repo.DeleteRecipe(1));
//         var controller = new RecipeController(mockRepo.Object);

//         // Act
//         var result = controller.DeleteRecipe(2);

//         // Assert
//         var actionResult = Assert.IsType<ActionResult<Recipe>>(result);
//         Assert.IsType<BadRequestResult>(actionResult.Result);
//     }

// }