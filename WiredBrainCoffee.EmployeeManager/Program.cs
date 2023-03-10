using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<EmployeeManagerDbContext>(
    options=> options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmployeeManagerDb")));

var app = builder.Build();
#region Migrazione a runtime
//Non usare in produzione, utile solo in sviluppo.

await EnsureDatabaseIsCreated(app.Services);

async Task EnsureDatabaseIsCreated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var context = scope.ServiceProvider.GetService<EmployeeManagerDbContext>();
    if (context != null)
    {
        await context.Database.MigrateAsync();

    }

}
#endregion Migrazione a runtime
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

