using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MealMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class MealController : ControllerBase
{
    private readonly MealContext _context;

    public MealController(MealContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Meal>> Create(Meal Meal)
    {
        _context.Meals.Add(Meal);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = Meal.Id }, Meal);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Meal>>> Get()
    {
        return await _context.Meals.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Meal>> GetById(string id)
    {
        var Meal = await _context.Meals.FindAsync(id);

        if (Meal == null)
        {
            return NotFound();
        }

        return Meal;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Meal Meal)
    {
        if (id == null || id != Meal.Id.ToString())
        {
            return BadRequest();
        }

        _context.Entry(Meal).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Meal = await _context.Meals.FindAsync(id);

        if (Meal == null)
        {
            return NotFound();
        }

        _context.Meals.Remove(Meal);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // search
    [HttpGet("search")] // GET /Meal/search?title=chicken
    public async Task<ActionResult<IEnumerable<Meal>>> Search([FromQuery] string title)
    {
        return await _context.Meals.Where(Meal => Meal.Title.Contains(title)).ToListAsync();
    }
}
