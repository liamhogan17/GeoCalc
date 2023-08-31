using GeoCalc.Clients;
using GeoCalc.Data.DBContext;
using GeoCalc.Data.Entities;
using GeoCalc.Interfaces;
using Microsoft.EntityFrameworkCore;
using Swashbuckle;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GeoCalcContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    options.UseSqlServer(connectionString);
});

builder.Services.AddSingleton<IClassClient, ClassClient>();
builder.Services.AddSingleton<IGradeClient, GradeClient>();
builder.Services.AddSingleton<ICache<Class>, ClassCache>();
builder.Services.AddSingleton<ICache<WholeGrade>, GradeCache>();

builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoint => endpoint.MapControllers());
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.UseSwagger();
app.UseSwaggerUI();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "";
});

app.Run();
