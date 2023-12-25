using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Online_Shop;
using Online_Shop.Areas.Identity.Data;
using OnlineShop.Data;
using OnlineShop.Models.WebMappers;
using OnlineShopDAL;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.Mappers;
using OnlineShopLogic.Implementation.Mappers.ManualMappers;
using OnlineShopLogic.Implementation.Services;
using OnlineShopLogic.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var authConnectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ??
                           throw new InvalidOperationException("Connection string 'AuthDbConnection' not found.");

builder.Services.AddDbContext<OnlineShopContext>(options =>
    options
        //.UseLazyLoadingProxies()
        .UseSqlServer(connectionString));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(authConnectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
});


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews(options =>
{
   // options.ModelBinderProviders.Insert(0, new DerivedTypeModelBinderProvider());
});



builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});


//builder.Services.AddTransient<OnlineShopContext>();
builder.Services.AddTransient<AuthDbContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IHomeService, HomeService>();

//builder.Services.AddTransient<IMapper<ItemEntity, Item>, ItemMapper>();
builder.Services.AddAutoMapper(typeof(ItemMappingProfile));
builder.Services.AddAutoMapper(typeof(CartItemMappingProfile));
builder.Services.AddAutoMapper(typeof(CartMappingProfile));
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddAutoMapper(typeof(PhotoMappingProfile));
builder.Services.AddAutoMapper(typeof(ReviewMappingProfile));

/*
builder.Services.AddTransient<IMapper<PhotoEntity, Photo>, PhotoMapper>();
builder.Services.AddTransient<IMapper<CategoryEntity, Category>, CategoryMapper>();
builder.Services.AddTransient<IMapper<CartItemEntity, CartItem>, CartItemMapper>();
builder.Services.AddTransient<IMapper<CustomerEntity, Customer>, CustomerMapper>();
builder.Services.AddTransient<IMapper<CartEntity, Cart>, CartMapper>();
builder.Services.AddTransient<IMapper<OrderEntity, Order>, OrderMapper>();
builder.Services.AddTransient<IMapper<ReviewEntity, Review>, ReviewMapper>();
*/

builder.Services.AddTransient<ItemWebModelMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();