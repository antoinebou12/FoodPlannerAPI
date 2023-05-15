using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ShoppingDbContext : DbContext
{
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
    public DbSet<FoodLocation> FoodLocations { get; set; }
    public DbSet<Bill> Bills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ShoppingDb;Trusted_Connection=True;");
    }
}

