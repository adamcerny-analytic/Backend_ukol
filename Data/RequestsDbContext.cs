using Microsoft.EntityFrameworkCore;
using RequestsAPI.Models;

namespace RequestsAPI.Data;

public class RequestsDbContext : DbContext
{
    public RequestsDbContext(DbContextOptions<RequestsDbContext> options) : base(options) { }

    public DbSet<Request> Requests { get; set; }
}