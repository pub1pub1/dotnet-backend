using Microsoft.AspNetCore.Mvc;
using TutorialApi.Models;
using TutorialApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TutorialsController : ControllerBase
{
    private readonly TutorialContext _context;

    public TutorialsController(TutorialContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tutorial>>> GetTutorials()
    {
        return await _context.Tutorials.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tutorial>> GetTutorial(long id)
    {
        var tutorial = await _context.Tutorials.FindAsync(id);

        if (tutorial == null)
        {
            return NotFound();
        }

        return tutorial;
    }

    [HttpPost]
    public async Task<ActionResult<Tutorial>> PostTutorial(Tutorial tutorial)
    {
        _context.Tutorials.Add(tutorial);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTutorial", new { id = tutorial.Id }, tutorial);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTutorial(long id)
    {
        var tutorial = await _context.Tutorials.FindAsync(id);
        if (tutorial == null)
        {
            return NotFound();
        }

        _context.Tutorials.Remove(tutorial);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}