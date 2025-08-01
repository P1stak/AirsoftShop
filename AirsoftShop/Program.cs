using AirsoftShop.Data.Interfaces;
using AirsoftShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Data.Interfacees;
using OnlineShop.DB.Data.Repository;
using OnlineShop.DB.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllersWithViews().AddViewOptions(options =>
{
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});

string connection = builder.Configuration.GetConnectionString("online_shop");
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(connection));

builder.Services.AddTransient<IProductsDbRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsDbRepository, CartsDbRepository>();
builder.Services.AddTransient<IFavoriteDbRepository, FavoriteDbRepository>();
builder.Services.AddTransient<IOrdersDbRepository, OrdersDbRepository>();
builder.Services.AddSingleton<IRolesInMemoryRepository, RolesInMemoryRepository>();
builder.Services.AddSingleton<IUserManager, UserManager>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
