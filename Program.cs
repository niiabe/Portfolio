using Portfolio.Components;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<SeedDataService>();
builder.Services.AddScoped<SimpleAuthService>();

// Add Authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PortfolioAuth";
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
    });

builder.Services.AddAuthorization();


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

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapPost("/loginhandler", async (HttpContext context, SimpleAuthService authService) =>
{
    var form = await context.Request.ReadFormAsync();
    var username = form["username"].ToString();
    var password = form["password"].ToString();

    if (authService.ValidateAdmin(username, password))
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(claimsIdentity);
        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        context.Response.Redirect("/admin");
    }
    else
    {
        context.Response.Redirect("/login?error=1");
    }
});

app.MapGet("/logouthandler", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.Redirect("/");
});


app.Run();