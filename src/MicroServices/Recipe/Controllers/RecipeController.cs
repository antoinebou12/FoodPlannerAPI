using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace RecipeMicroservice.Controllers;


[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly RecipeContext _context;
    private readonly IDistributedCache _cache;
    private readonly ILogger<RecipeController> _logger;

    public RecipeController(RecipeContext context, IDistributedCache cache, ILogger<RecipeController> logger)
    {
        _context = context;
        _cache = cache;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> Create(Recipe recipe)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        // Send Kafka message
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };  // Configure Kafka server here
        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                var message = new Message<Null, string> { Value = JsonSerializer.Serialize(recipe) };
                await producer.ProduceAsync("recipe-created-topic", message);  // Use your topic name
                _logger.LogInformation($"Kafka message sent to topic 'recipe-created-topic' with recipe ID {recipe.Id}");
            }
            catch (ProduceException<Null, string> e)
            {
                _logger.LogError($"Error occured while sending Kafka message: {e.Error.Reason}");
            }
        }

        return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> Get()
    {
        _logger.LogInformation("Fetching all recipes");

        var cacheKey = "GetAllRecipes";
        var recipes = await _cache.GetStringAsync(cacheKey);

        if(recipes == null)
        {
            recipes = JsonSerializer.Serialize(await _context.Recipes.ToListAsync());

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            await _cache.SetStringAsync(cacheKey, recipes, options);
        }

        return Ok(JsonSerializer.Deserialize<IEnumerable<Recipe>>(recipes));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetById(string id)
    {
        var cacheKey = $"Recipe-{id}";
        var cachedRecipe = await _cache.GetStringAsync(cacheKey);

        if(cachedRecipe != null)
        {
            return Ok(JsonSerializer.Deserialize<Recipe>(cachedRecipe));
        }

        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe == null)
        {
            _logger.LogWarning($"Recipe with ID {id} not found");
            return NotFound();
        }

        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
        await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(recipe), options);

        return recipe;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe == null)
        {
            _logger.LogWarning($"Recipe with ID {id} not found");
            return NotFound();
        }

        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();

        await _cache.RemoveAsync($"Recipe-{id}");

        return NoContent();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Recipe>>> Search([FromQuery] string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            _logger.LogWarning("Attempted search with empty or whitespace title");
            return BadRequest("Title cannot be empty or whitespace");
        }

        return await _context.Recipes
            .Where(recipe => recipe.Title.Contains(title))
            .ToListAsync();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Recipe recipe)
    {
        if (string.IsNullOrWhiteSpace(id) || recipe == null || id != recipe.Id.ToString())
        {
            _logger.LogWarning($"Invalid update attempt for Recipe with ID {id}");
            return BadRequest();
        }

        try
        {
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var cacheKey = $"Recipe-{id}";
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            // Update the cache
            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(recipe), options);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            if (!await RecipeExists(id))
            {
                _logger.LogError($"Update failed. Recipe with ID {id} not found", ex);
                return NotFound();
            }
            else
            {
                _logger.LogError($"Database concurrency error on updating Recipe with ID {id}", ex);
                throw;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error occurred while updating Recipe with ID {id}", ex);
            throw;
        }

        return NoContent();
    }

    private async Task<bool> RecipeExists(string id)
    {
        return await _context.Recipes.AnyAsync(e => e.Id.ToString() == id);
    }

}
