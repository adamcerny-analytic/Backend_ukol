using Microsoft.EntityFrameworkCore;
using RequestsAPI.Data;
using RequestsAPI.Models;

namespace RequestsAPI.Services
{
    public class RequestService
    {
        private readonly RequestsDbContext _context;

        public RequestService(RequestsDbContext context)
        {
            _context = context;
        }

        // Získat všechny požadavky
        public async Task<List<Request>> GetAllAsync() =>
            await _context.Requests.ToListAsync();

        // Získat požadavek podle Id
        public async Task<Request?> GetByIdAsync(int id) =>
            await _context.Requests.FindAsync(id);

        // Vytvořit nový požadavek
        public async Task<Request> CreateAsync(Request request)
        {
            
            request.Id = 0;
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        // Aktualizovat požadavek
        public async Task<bool> UpdateAsync(int id, Request request)
        {
            var existing = await _context.Requests.FindAsync(id);
            if (existing == null) return false;

            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.Priority = request.Priority;
            existing.Category = request.Category;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Smazat požadavek
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Requests.FindAsync(id);
            if (existing == null) return false;

            _context.Requests.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
