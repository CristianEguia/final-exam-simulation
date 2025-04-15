using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Agrega soporte a Entity Framework con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔓 Habilita CORS para permitir conexión desde el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 👇 Agrega soporte a controladores
builder.Services.AddControllers();

var app = builder.Build();

// 🧩 Usa CORS
app.UseCors("AllowAll");

// 🔐 Middleware para autenticación/autorización (aunque no uses, es requerido por defecto)
app.UseAuthorization();

app.MapControllers();

// 👇 Este bloque ejecuta las migraciones al iniciar el backend
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
