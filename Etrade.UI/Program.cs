using Etrade.Dal;
using Etrade.Entity.Concretes;
using Etrade.Repos.Abstracts;
using Etrade.Repos.Concretes;
using Etrade.UI.Models;
using Etrade.UW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TradeContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));

builder.Services.AddScoped<ProductModel>();
builder.Services.AddScoped<CategoryModel>();
builder.Services.AddScoped<UsersModel>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(5);
});
builder.Services.AddScoped<IBasketDetailRep, BasketDetailRep<BasketDetail>>();
builder.Services.AddScoped<IBasketMasterRep, BasketMasterRep<BasketMaster>>();
builder.Services.AddScoped<ICategoriesRep, CategoriesRep<Categories>>();
builder.Services.AddScoped<ICityRep, CityRep<City>>();
builder.Services.AddScoped<ICountyRep, CountyRep<County>>();
builder.Services.AddScoped<IProductsRep, ProductsRep<Products>>();
builder.Services.AddScoped<IOrdersRep, OrdersRep<Orders>>();
builder.Services.AddScoped<IUsersRep, UsersRep<Users>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<UsersModel>();
builder.Services.AddScoped<List<County>>();
builder.Services.AddScoped<List<Users>>();
builder.Services.AddScoped<ShippingModel>();

builder.Services.AddScoped<BasketMaster>();
builder.Services.AddScoped<BasketDetail>();
builder.Services.AddScoped<BasketDetailModel>();
builder.Services.AddScoped<CategoryModel>();
builder.Services.AddScoped<OrdersModel>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
