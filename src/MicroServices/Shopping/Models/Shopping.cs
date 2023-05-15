using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShoppingList
{
    [Key]
    public Guid Id { get; set; }
    public ICollection<ShoppingListItem> Items { get; set; }
}

public class ShoppingListItem
{
    [Key]
    public Guid Id { get; set; }
    public Food Food { get; set; }
    public float Quantity { get; set; }
    public string Unit { get; set; }
    public FoodLocation Location { get; set; }
}

public class FoodLocation
{
    [Key]
    public Guid Id { get; set; }
    public string StoreName { get; set; }
    public string Aisle { get; set; }
    public string Website { get; set; }
    public string PhysicalAddress { get; set; }
}

public class Bill
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public double TotalAmount { get; set; }
    public Guid ShoppingListId { get; set; }

    [ForeignKey("ShoppingListId")]
    public ShoppingList ShoppingList { get; set; }
}
