using focus_flow.API.Data;
using focus_flow.Shared.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace focus_flow.API.controllers;


[ApiController]
[Route("[controller]")]
public class tagController : ControllerBase
{
    private readonly tasksDbContext _context;

    public tagController(tasksDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<tag>>> GetTags()
    {
        return await _context.Tags
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<tag>> GetTag(int id)
    {
        var tag = await _context.Tags
            .FirstOrDefaultAsync(t => t.Id == id);
        return tag;
    }

    [HttpPost]
    public async Task<ActionResult<tag>> CreateTag(tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null) return NotFound();

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}