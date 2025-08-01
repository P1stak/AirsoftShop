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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    if (!dbContext.Products.Any())
    {
        dbContext.Products.AddRange(
            new Product("АКС-74", 23500, "Автомат страйкбольный E&L АКС-74 ELS-74 MN Gen2", "/images/ak74.jpg"),
            new Product("CM.518", 10000, "Страйкбольная штурмовая винтовка Cyma CM.518", "/images/cyma518.jpg"),
            new Product("Colt 1911", 2500, "Пистолет страйкбольный Colt 1911 STTI Green Gas", "/images/1911.jpg"),
            new Product("MP7", 5000, "Пистолет-пулемет страйкбольный MP7 R4 WELL Plastic Body", "/images/mp7.jpg"),
            new Product("РПК-74М", 22000, "Пулемет страйкбольный РПК-74М CYMA CM.052А", "/images/rpk-74m.jpg"),
            new Product("Mauser C96", 4000, "Пистолет страйкбольный WELL Mauser C96 CO2", "/images/c96.jpg"),
            new Product("G36-C", 9000, "Автомат страйкбольный G36-C Specna Arms SA-G12 EBB Tan", "/images/G36-C.jpg"),
            new Product("M56DL", 4500, "Дробовик EE M56DL Black", "/images/M56DL.jpg"),
            new Product("ГП-1", 12000 ,"Подствольный гранатомет Pyrosoft ГП-1 ЗНИЧ", "/images/GP1.jpg"),
            new Product("Fenix AER-03", 1200, "Выносная тактическая кнопка Fenix AER-03 v2.0", "/images/aer.jpg"),
            new Product("Г52Д", 4500 , "Гильза Г52Д для гранатомёта страйкбольного Pyrosof", "/images/G52D.jpg")
        );
        dbContext.SaveChanges();
    }
}

app.Run();
