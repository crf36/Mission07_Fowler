using Microsoft.EntityFrameworkCore;
using Mission07_Fowler.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options => // Links to my Sqlite connection string
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sqliteConnection"]);
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();