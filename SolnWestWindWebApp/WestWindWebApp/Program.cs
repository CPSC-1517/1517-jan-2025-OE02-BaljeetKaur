using WestWindWebApp.Components;
using ClassWestWindsystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.WestWindExtensionServices(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WWDB")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// retreive the connection string from the appsettings.json file 
// and register the connection string with the DbContext

var connectionString = builder.Configuration.GetConnectionString("WWDB");

//setup the reigstartion of services to be available for use by this application
// the technique used in this example has registration encapsulated within the class library



app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
