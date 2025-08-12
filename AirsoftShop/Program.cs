using AirsoftShop.Data.Interfaces;
using AirsoftShop.Data.Repositories;
using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Context;
using OnlineShop.DB.Data.Interfacees;
using OnlineShop.DB.Data.Repository;
using OnlineShop.DB.Models;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// сериализаци€
builder.Host.UseSerilog((context, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration));

// добавление контроллеров с представлени€ми в коллекцию сервисов
builder.Services.AddControllersWithViews();

// –егистраци€ репозиториев
builder.Services.AddTransient<IOrdersDbRepository, OrdersDbRepository>();
builder.Services.AddTransient<IProductsDbRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsDbRepository, CartsDbRepository>();
builder.Services.AddTransient<IFavoriteDbRepository, FavoriteDbRepository>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("ru-RU")
    };
    options.DefaultRequestCulture = new RequestCulture("ru-RU");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

string connection = builder.Configuration.GetConnectionString("online_shop");

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection));

// Ќастройка Identity с использованием основного контекста
builder.Services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connection));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";

    options.Cookie = new CookieBuilder
    {
        IsEssential = true,
        HttpOnly = true,
        SameSite = SameSiteMode.Lax
    };
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRequestLocalization();

app.UseSerilogRequestLogging();

//app.UseStaticFiles(new StaticFileOptions()
//{
//    OnPrepareResponse = ctx =>
//    {
//        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
//    }
//});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, rolesManager);
}

app.Run();