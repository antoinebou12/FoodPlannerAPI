using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class RecipeContext : DbContext
{
    public RecipeContext(DbContextOptions<RecipeContext> options)
        : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FoodPlannerDb;Trusted_Connection=True;");
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<NutritionInfo> NutritionInfos { get; set; }
    public DbSet<Tag> Tags { get; set; }
}
