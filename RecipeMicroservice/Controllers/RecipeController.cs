using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace RecipeMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly RecipeContext _context;

    public RecipeController(RecipeContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> Create(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> Get()
    {
        return await _context.Recipes.ToListAsync();
    }

[HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetById(string id)
    {
        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe == null)
        {
            return NotFound();
        }

        return recipe;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Recipe recipe)
    {
        if (id == null || id != recipe.Id.ToString())
        {
            return BadRequest();
        }

        _context.Entry(recipe).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe == null)
        {
            return NotFound();
        }

        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // search
    [HttpGet("search")] // GET /recipe/search?title=chicken
    public async Task<ActionResult<IEnumerable<Recipe>>> Search([FromQuery] string title)
    {
        return await _context.Recipes.Where(recipe => recipe.Title.Contains(title)).ToListAsync();
    }
}
