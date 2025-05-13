using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using LivrosBusiness;
using LivrosData;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var baseConnection = builder.Configuration.GetConnectionString("DefaultConnection");

var connectionString = $"User Id={dbUser};Password={dbPassword};{baseConnection}";

builder.Services.AddDbContext<LivrosDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddScoped<LivroService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
