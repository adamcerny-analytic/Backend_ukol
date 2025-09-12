using Microsoft.EntityFrameworkCore;
using RequestsAPI.Data;
using RequestsAPI.Models;
using System.Text.Json;

namespace RequestsAPI.Services
{
    public class RequestService
    {
        private readonly RequestsDbContext _context;

        public RequestService(RequestsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Request>> GetAllAsync() =>
            await _context.Requests.ToListAsync();

        public async Task<Request?> GetByIdAsync(int id) =>
            await _context.Requests.FindAsync(id);

        public async Task<Request> CreateAsync(Request request)
        {
            request.CreatedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;

            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            await AddAuditLog(request, "Create", null, JsonSerializer.Serialize(request));
            return request;
        }

        public async Task<bool> UpdateAsync(int id, Request request)
        {
            var existing = await _context.Requests.FindAsync(id);
            if (existing == null) return false;

            var oldData = JsonSerializer.Serialize(existing);

            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.Priority = request.Priority;
            existing.Category = request.Category;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            await AddAuditLog(existing, "Update", oldData, JsonSerializer.Serialize(existing));
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Requests.FindAsync(id);
            if (existing == null) return false;

            var oldData = JsonSerializer.Serialize(existing);

            _context.Requests.Remove(existing);
            await _context.SaveChangesAsync();

            await AddAuditLog(existing, "Delete", oldData, null);
            return true;
        }

        private async Task AddAuditLog(Request request, string action, string? oldValue, string? newValue)
        {
            var log = new AuditLog
            {
                EntityName = nameof(Request),
                EntityId = request.Id,
                Action = action,
                OldValue = oldValue ?? string.Empty,
                NewValue = newValue ?? string.Empty,
                Timestamp = DateTime.UtcNow
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
