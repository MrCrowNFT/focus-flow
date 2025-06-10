using focus_flow.API.Data;
using focus_flow.Shared.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace focus_flow.API.controllers;

[ApiController]
[Route("/[controller]")]
public class taskController : ControllerBase
{
    private readonly tasksDbContext _context;
    public taskController(tasksDbContext context)
    {
        _context = context;
    }

    //simple get all tasks method //todo should make a user model and implement auth
    [HttpGet]
    public async Task<ActionResult<IEnumerable<taskItem>>> GetTasks()
    {
        return await _context.Tasks
            .Include(t => t.Tags)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<taskItem>> GetTask(int id)
    {
        var task = await _context.Tasks
            .Include(t => t.Tags)
            .FirstOrDefaultAsync(t => t.Id == id);
        return task;
    }

    [HttpPost]
    public async Task<ActionResult<taskItem>> CreateTask(taskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    

}