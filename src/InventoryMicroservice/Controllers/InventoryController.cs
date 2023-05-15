using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InventoryMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryContext _context;

    public InventoryController(InventoryContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Inventory>> Create(Inventory Inventory)
    {
        _context.Inventorys.Add(Inventory);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = Inventory.Id }, Inventory);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inventory>>> Get()
    {
        return await _context.Inventorys.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Inventory>> GetById(string id)
    {
        var Inventory = await _context.Inventorys.FindAsync(id);

        if (Inventory == null)
        {
            return NotFound();
        }

        return Inventory;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Inventory Inventory)
    {
        if (id == null || id != Inventory.Id.ToString())
        {
            return BadRequest();
        }

        _context.Entry(Inventory).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Inventory = await _context.Inventorys.FindAsync(id);

        if (Inventory == null)
        {
            return NotFound();
        }

        _context.Inventorys.Remove(Inventory);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // search
    [HttpGet("search")] // GET /Inventory/search?title=chicken
    public async Task<ActionResult<IEnumerable<Inventory>>> Search([FromQuery] string title)
    {
        return await _context.Inventorys.Where(Inventory => Inventory.Title.Contains(title)).ToListAsync();
    }
}
