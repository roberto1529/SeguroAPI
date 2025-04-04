using Microsoft.EntityFrameworkCore;
using SeguroAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar conexión a SQL Server
builder.Services.AddDbContext<SeguroDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS para aceptar cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar CORS antes de Authorization
app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();
app.Run();
