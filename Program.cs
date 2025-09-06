using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RequestsAPI.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ====== Přidání DbContextu s SQLite ======
builder.Services.AddDbContext<RequestsDbContext>(options =>
    options.UseSqlite("Data Source=requests.db"));

// ====== Přidání Controllers ======
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


// ====== Přidání Swagger/OpenAPI ======
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Requests API", Version = "v1" });
});

var app = builder.Build();

// ====== Middleware ======
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Requests API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
