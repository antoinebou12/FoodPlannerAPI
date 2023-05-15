using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;


public class Recipe
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<Instruction> Instructions { get; set; }  = new List<Instruction>();
    public NutritionInfo NutritionInfo { get; set; } = new NutritionInfo();
    public ICollection<Tag> Tags { get; set; }  = new List<Tag>();
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public int Servings { get; set; }
}

public class Ingredient
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
}

public class Instruction
{
    [Key]
    public Guid Id { get; set; }
    public int StepNumber { get; set; }
    public string Description { get; set; } = string.Empty;
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
    public string Name { get; set; } = string.Empty;
}


