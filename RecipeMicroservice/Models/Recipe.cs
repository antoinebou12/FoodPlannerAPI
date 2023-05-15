using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


public class Recipe
{
    [Key]
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Instruction> Instructions { get; set; }
    public NutritionInfo NutritionInfo { get; set; }
    public List<string> Tags { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int Servings { get; set; }
}

public class Ingredient
{
    public string Name { get; set; }
    public float Quantity { get; set; }
    public string Unit { get; set; }
}

public class Instruction
{
    public int StepNumber { get; set; }
    public string Description { get; set; }
}

public class NutritionInfo
{
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
    public string Name { get; set; }
}


