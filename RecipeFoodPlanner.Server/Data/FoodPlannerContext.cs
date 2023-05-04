public class FoodPlannerContext : DbContext
{
    public RecipeFoodPlannerContext(DbContextOptions<RecipeFoodPlannerContext> options)
        : base(options)
    {
    }

    // Define DbSet properties for each model, e.g.:
    // public DbSet<Recipe> Recipes { get; set; }
    // public DbSet<Food> Foods { get; set; }
    // ...
}
