using EverWave.Data;
using EverWave.Repository.Extensions;
using EverWave.Services.Extensions;

using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddDbContext<EverWaveContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("EverWave");
    options.UseNpgsql(connectionString, config => config.MigrationsAssembly("EverWave.Data"));
});

builder.Services.AddCommonServices();
builder.Services.AddApiServices();
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();