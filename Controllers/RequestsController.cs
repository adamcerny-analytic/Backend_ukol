using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestsAPI.Data;
using RequestsAPI.Models;

namespace RequestsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestsController : ControllerBase
{
    private readonly RequestsDbContext _context;

    public RequestsController(RequestsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        => await _context.Requests.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Request>> GetRequest(int id)
    {
        var request = await _context.Requests.FindAsync(id);
        if (request == null) return NotFound();
        return request;
    }

    [HttpPost]
    public async Task<ActionResult<Request>> CreateRequest([FromBody] Request request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            return BadRequest("Title is required.");

        request.CreatedAt = DateTime.UtcNow;
        request.UpdatedAt = DateTime.UtcNow;

        _context.Requests.Add(request);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRequest), new { id = request.Id }, request);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRequest(int id, [FromBody] Request request)
    {
        if (id != request.Id) return BadRequest("ID mismatch.");

        request.UpdatedAt = DateTime.UtcNow;
        _context.Entry(request).State = EntityState.Modified;

        try { await _context.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Requests.Any(e => e.Id == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
        var request = await _context.Requests.FindAsync(id);
        if (request == null) return NotFound();

        _context.Requests.Remove(request);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
