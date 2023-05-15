using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MealPlan
{
    [Key]
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Meal> Meals { get; set; }
}

public class Meal
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateTime { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
}

public class NutritionInfo
{
    [Key]
    public Guid Id { get; set; }
    public float Calories { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbohydrates { get; set; }
    public float Fiber { get; set; }
    public float Sugar { get; set; }
    public float Sodium { get; set; }
}

public class Food
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public NutritionInfo NutritionInfo { get; set; }
}
