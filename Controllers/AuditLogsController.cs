using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestsAPI.Data;
using RequestsAPI.Models;

namespace RequestsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private readonly RequestsDbContext _context;

        public AuditLogsController(RequestsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuditLog>>> GetAll()
        {
            return await _context.AuditLogs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuditLog>> GetById(int id)
        {
            var log = await _context.AuditLogs.FindAsync(id);
            if (log == null) return NotFound();
            return log;
        }
    }
}
