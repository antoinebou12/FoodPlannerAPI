using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ShoppingMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingController : ControllerBase
{
    private readonly ShoppingContext _context;

    public ShoppingController(ShoppingContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Shopping>> Create(Shopping Shopping)
    {
        _context.Shoppings.Add(Shopping);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = Shopping.Id }, Shopping);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shopping>>> Get()
    {
        return await _context.Shoppings.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shopping>> GetById(string id)
    {
        var Shopping = await _context.Shoppings.FindAsync(id);

        if (Shopping == null)
        {
            return NotFound();
        }

        return Shopping;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Shopping Shopping)
    {
        if (id == null || id != Shopping.Id.ToString())
        {
            return BadRequest();
        }

        _context.Entry(Shopping).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Shopping = await _context.Shoppings.FindAsync(id);

        if (Shopping == null)
        {
            return NotFound();
        }

        _context.Shoppings.Remove(Shopping);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // search
    [HttpGet("search")] // GET /Shopping/search?title=chicken
    public async Task<ActionResult<IEnumerable<Shopping>>> Search([FromQuery] string title)
    {
        return await _context.Shoppings.Where(Shopping => Shopping.Title.Contains(title)).ToListAsync();
    }
}
