using EverWave.Data;
using EverWave.Domain.Services;
using EverWave.Repository.Extensions;
using EverWave.Services.Extensions;
using EverWave.Web.Components;
using EverWave.Web.Data;

using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<EverWaveContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("EverWave");
    options.UseNpgsql(connectionString, config => config.MigrationsAssembly("EverWave.Data"));
});
builder.Services.AddServices();
builder.Services.AddCommonServices();
builder.Services.AddRepositories();

builder.Services.AddTransient<IUnidadeData, UnidadeData>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();