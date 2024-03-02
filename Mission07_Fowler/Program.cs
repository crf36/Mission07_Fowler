using Microsoft.EntityFrameworkCore;
using Mission07_Fowler.Models;

// Create a web application builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configures services needed for the application.

// Sets up services between build and actual build
builder.Services.AddControllersWithViews();

// Add a DbContext to the services container.
// Configures Entity Framework to use SQLite with the connection string from the app's configuration.
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sqliteConnection"]);
});

// Build the application
var app = builder.Build();

// Configure middleware components

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Serve static files (e.g., CSS, images) from wwwroot
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Define the default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the application
app.Run();
