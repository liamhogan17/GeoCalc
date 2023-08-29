using BrainDump.Clients;
using BrainDump.Data.DBContext;
using BrainDump.Data.Entities;
using BrainDump.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BrainDumpContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    options.UseSqlServer(connectionString);
});

builder.Services.AddSingleton<IClassClient, ClassClient>();
builder.Services.AddSingleton<IGradeClient, GradeClient>();
builder.Services.AddSingleton<ICache<Class>, ClassCache>();
builder.Services.AddSingleton<ICache<WholeGrade>, GradeCache>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
