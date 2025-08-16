using Portfolio.Components;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Add this line with your other service registrations
builder.Services.AddScoped<SeedDataService>();
// Add this line with your other service registrations
builder.Services.AddScoped<SimpleAuthService>();

// Add SQLite Database
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlite("Data Source=portfolio.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();