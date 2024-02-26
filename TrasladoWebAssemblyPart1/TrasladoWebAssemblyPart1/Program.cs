using Microsoft.EntityFrameworkCore;
using TrasladoWebAssemblyPart1.Components;
using TrasladoWebAssemblyPart1.DAL;
using TrasladoWebAssemblyPart1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var conexion = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(conexion));

builder.Services.AddScoped<TicketsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
