using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using ThreeTrees.Data;
using ThreeTrees.Repositorios;
using ThreeTrees.Repositorios.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar tamanho máximo de upload de arquivos
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 50_000_000; // 50 MB
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Entity Framework
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<ThreeTreesDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

// Configurar repositórios
builder.Services.AddScoped<ITrilhaRepositorio, TrilhaRepositorio>();

var app = builder.Build();

// Servir arquivos estáticos
app.UseStaticFiles();

// Detectar ambiente do Render
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    app.Urls.Add($"http://*:{port}"); // Render usa porta 8080
}

// Sempre habilitar Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Só redirecionar HTTPS localmente
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
