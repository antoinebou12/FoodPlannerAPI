using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class InventoryDbContext : DbContext
{

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<InventoryAtHome> InventoryAtHomes { get; set; }
    public DbSet<FoodItem> FoodItems { get; set; }
}

