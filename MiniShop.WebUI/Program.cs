using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniShop.Business.Abstract;
using MiniShop.Business.Concreate;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concreate;
using MiniShop.WebUI.Identity;

namespace MiniShop.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var sqliteConnection = builder.Configuration.GetConnectionString("SqliteCon");
        builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlite(sqliteConnection));

        builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;

            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.AllowedForNewUsers = true;


            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedEmail = false;
        }
        );

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/account/login";
            options.LogoutPath = "/account/logout";
            options.AccessDeniedPath = "/account/accessdenied";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromHours(500);
            options.Cookie = new CookieBuilder
            {
                HttpOnly = true,
                Name = ".MiniShop.Security.Cookie"
            };
        });


        builder.Services.AddDbContext<Context_MiniShop>(options => options.UseSqlite(sqliteConnection));

        builder.Services.AddScoped<ICategoryService, CategoryManager>();
        builder.Services.AddScoped<IProductService, ProductManager>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

        builder.Services.AddControllersWithViews();

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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
                         name: "productList",
                         pattern: "product-list",
                         defaults: new { controller = "Admin", action = "ProductList" }
                     );

        app.MapControllerRoute(
                       name: "search",
                       pattern: "search",
                       defaults: new { controller = "MiniShop", action = "Search" }
                   );

        app.MapControllerRoute(
                        name: "products",
                        pattern: "product/{category?}",
                        defaults: new { controller = "MiniShop", action = "List" }
                    );

        app.MapControllerRoute(
                   name: "details",
                   pattern: "{url}",
                   defaults: new { controller = "MiniShop", action = "Details" }
               );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}