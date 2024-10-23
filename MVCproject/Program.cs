using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCproject.config;
using MVCproject.Models;
using MVCproject.Repository;
using System.Configuration;

namespace MVCproject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
    

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
                );
            builder.Services.AddScoped<ITRepository<Category>,TRepository<Category>>();
            builder.Services.AddScoped<ITRepository<Product>,TRepository<Product>>();
            builder.Services.AddScoped<ITRepository<ApplicationUser>,TRepository<ApplicationUser>>();
            builder.Services.AddScoped<ITRepository<CartItem>,TRepository<CartItem>>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
           builder.Services.AddScoped<IOrderRepository, OrderRepository>();
           

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
