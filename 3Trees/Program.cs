using _3Trees.Integracao;
using _3Trees.Integracao.Interfaces;
using _3Trees.Integracao.Refit;
using _3Trees.Integracao.Response;
using Microsoft.EntityFrameworkCore;
using Refit;
using ThreeTrees.Data;
using ThreeTrees.Repositorios;
using ThreeTrees.Repositorios.Interface;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Via Cep
builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://viacep.com.br/");
});

// Entity Framework + PostgreSQL
builder.Services.AddDbContext<ThreeTreesDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase"))
);

builder.Services.AddScoped<ITrilhaRepositorio, TrilhaRepositorio>();
builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>();

var app = builder.Build();

app.UseStaticFiles();

// Render
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    app.Urls.Add($"http://*:{port}");
}

// Swagger sempre
app.UseSwagger();
app.UseSwaggerUI();

// CORS AQUI
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
