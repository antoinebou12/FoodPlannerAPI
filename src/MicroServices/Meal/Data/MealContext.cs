using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class MealPlanDbContext : DbContext
{

    public MealPlanDbContext(DbContextOptions<MealPlanDbContext> options)
        : base(options)
    {
    }


    public DbSet<MealPlan> MealPlans { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<NutritionInfo> NutritionInfos { get; set; }
    public DbSet<Food> Foods { get; set; }
}


