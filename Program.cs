using Microsoft.EntityFrameworkCore;
using OrgMgmt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext using SQLite (Required for macOS/Linux steps)
builder.Services.AddDbContext<OrgDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

var app = builder.Build();

// Create the database if it does not already exist
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrgDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();