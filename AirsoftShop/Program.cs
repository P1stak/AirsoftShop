using AirsoftShop.Data.Interfaces;
using AirsoftShop.Data.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)); // Serilog

builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddViewOptions(options =>
{
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});

builder.Services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
builder.Services.AddSingleton<ICartsRepository, CartsInMemoryRepository>();
builder.Services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
builder.Services.AddSingleton<IRolesInMemoryRepository, RolesInMemoryRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSerilogRequestLogging(); // Serilog

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
