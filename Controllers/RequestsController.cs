using Microsoft.AspNetCore.Mvc;
using RequestsAPI.Models;
using RequestsAPI.Services;

namespace RequestsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly RequestService _service;

        public RequestsController(RequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> Get() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> Get(int id)
        {
            var request = await _service.GetByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<Request>> Post(Request request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Get), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Request request)
        {
            request.Id = id;
            var updated = await _service.UpdateAsync(request);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
