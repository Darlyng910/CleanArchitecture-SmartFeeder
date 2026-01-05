using Aplication.Mapping;
using Aplication.UseCases;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// CORS: Política Permisiva para Desarrollo
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Connection String
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Infraestructure")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
// Repositories
builder.Services.AddScoped<IMascota, MascotaRepository>();
builder.Services.AddScoped<IHorario, HorarioRepository>();
builder.Services.AddScoped<IAlimentacion, AlimentacionRepository>();
// Casos de Uso
builder.Services.AddScoped<CrearMascota>();
builder.Services.AddScoped<CrearHorario>();
builder.Services.AddScoped<RegistrarAlimentacion>();

builder.Services.AddScoped<ObtenerMascotas>();
builder.Services.AddScoped<ObtenerMascotaPorId>();
builder.Services.AddScoped<ActualizarMascota>();

builder.Services.AddScoped<ObtenerHorariosPorMascota>();
builder.Services.AddScoped<EliminarHorario>();

builder.Services.AddScoped<ObtenerHistorialAlimentacion>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Cors
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
