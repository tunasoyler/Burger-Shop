using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Context;
using System;
using static MVC.Models.Context.BurgerContext;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BurgerContext>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();

            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BurgerContext>();
            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IdentityCookie";
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                opt.SlidingExpiration = true;
                opt.LoginPath = "/User/Login";
            });

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "ShoppingCartCookie";
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.SlidingExpiration = true;
            });

            builder.Services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            });

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
            app.UseSession();

            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "{AdminArea}/{controller=Home}/{action=GetHome}/{id?}");

            app.MapControllerRoute(
                name: "default",                
                pattern: "{controller=Home}/{action=GetHome}/{id?}");

            app.Run();
        }
    }
}