using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using KaryawanApi.Data;

var builder = WebApplication.CreateBuilder(args);

// === EF Core SQL Server ===
// connection string ada di appsettings.json -> "ConnectionStrings:DefaultConnection"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// === Tambahkan Controllers ===
builder.Services.AddControllers();

// === CORS (supaya bisa diakses dari MAUI / Postman) ===
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowALL", b =>
        b.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

// === Swagger ===
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Karyawan API",
        Version = "v1",
        Description = "API sederhana untuk CRUD data Karyawan"
    });
});

var app = builder.Build();

// === Middleware ===
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Karyawan API v1");
        // c.RoutePrefix = string.Empty; // swagger muncul di root URL
    });
}

app.UseCors("AllowALL");

app.UseHttpsRedirection();

app.UseAuthorization();

// === Map Controllers ===
app.MapControllers();

// Endpoint root sederhana
app.MapGet("/", () => "Karyawan API running...");

app.Run();
