using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class InventoryDbContext : DbContext
{
    public DbSet<InventoryAtHome> InventoryAtHomes { get; set; }
    public DbSet<FoodItem> FoodItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InventoryDb;Trusted_Connection=True;");
    }
}

