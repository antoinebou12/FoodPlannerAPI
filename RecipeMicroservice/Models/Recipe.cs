using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


public class Recipe
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<Instruction> Instructions { get; set; }
    public NutritionInfo NutritionInfo { get; set; }
    public ICollection<string> Tags { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int Servings { get; set; }
}

public class Ingredient
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string Unit { get; set; }
}

public class Instruction
{
    [Key]
    public Guid Id { get; set; }
    public int StepNumber { get; set; }
    public string Description { get; set; }
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

public class Tag
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
}


