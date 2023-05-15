using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class RecipeContext : DbContext
{
    public RecipeContext(DbContextOptions<RecipeContext> options)
        : base(options) {}

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<NutritionInfo> NutritionInfos { get; set; }
    // public DbSet<Tag> Tags { get; set; }

    public static void SeedData(ModelBuilder modelBuilder)
    {

        var chickenSoupId = Guid.NewGuid();
        var beefStewId = Guid.NewGuid();

        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = chickenSoupId,
                Title = "Chicken Soup",
                Description = "A hearty chicken soup with noodles and vegetables",
                PrepTime = 10,
                CookTime = 60,
                Servings = 4,
            },
            new Recipe
            {
                Id = beefStewId,
                Title = "Beef Stew",
                Description = "A hearty beef stew with potatoes and carrots",
                PrepTime = 20,
                CookTime = 180,
                Servings = 6,
            }
        );

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "Chicken",
                Quantity = 1,
                Unit = "Whole",
            },
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "Beef",
                Quantity = 500,
                Unit = "Grams",
            }
        );

        modelBuilder.Entity<Instruction>().HasData(
            new Instruction
            {
                Id = Guid.NewGuid(),
                StepNumber = 1,
                Description = "Boil the chicken in a large pot of water for 30 minutes",
            },
            new Instruction
            {
                Id = Guid.NewGuid(),
                StepNumber = 2,
                Description = "Remove the chicken from the pot and let cool",
            }
        );

        modelBuilder.Entity<NutritionInfo>().HasData(
            new NutritionInfo
            {
                Id = Guid.NewGuid(),
                Calories = 200,
                Protein = 20,
                Fat = 10,
                Carbohydrates = 10,
                Fiber = 5,
                Sugar = 5,
                Sodium = 100,
            },
            new NutritionInfo
            {
                Id = Guid.NewGuid(),
                Calories = 300,
                Protein = 30,
                Fat = 15,
                Carbohydrates = 15,
                Fiber = 10,
                Sugar = 10,
                Sodium = 200,
            }
        );

        // modelBuilder.Entity<Tag>().HasData(
        //     new Tag
        //     {
        //         Id = Guid.NewGuid(),
        //         Name = "Chicken",
        //     },
        //     new Tag
        //     {
        //         Id = Guid.NewGuid(),
        //         Name = "Beef",
        //     }
        // );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().ToTable("Recipe");
        modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        modelBuilder.Entity<Instruction>().ToTable("Instruction");
        modelBuilder.Entity<NutritionInfo>().ToTable("NutritionInfo");
        // modelBuilder.Entity<Tag>().ToTable("Tag");

        SeedData(modelBuilder);
    }
}
