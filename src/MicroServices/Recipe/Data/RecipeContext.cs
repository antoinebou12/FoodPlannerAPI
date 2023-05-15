using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class RecipeContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<NutritionInfo> NutritionInfos { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().ToTable("Recipe");
        modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        modelBuilder.Entity<Instruction>().ToTable("Instruction");
        modelBuilder.Entity<NutritionInfo>().ToTable("NutritionInfo");
        modelBuilder.Entity<Tag>().ToTable("Tag");
    }
}
