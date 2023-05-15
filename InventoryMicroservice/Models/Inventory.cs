using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class InventoryAtHome
{
    [Key]
    public Guid Id { get; set; }
    public ICollection<FoodItem> FoodItems { get; set; }
}

public class FoodItem
{
    [Key]
    public Guid Id { get; set; }
    public Food Food { get; set; }
    public float Quantity { get; set; }
    public string Unit { get; set; }
    public DateTime ExpirationDate { get; set; }
}
