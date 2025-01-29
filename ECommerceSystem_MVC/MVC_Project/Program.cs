using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVC_Project.DbContext;
using MVC_Project.Models;
using MVC_Project.Services;

namespace MVC_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Identity Services 
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity Options (Optional)
            // Customize Password Requirements
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                // options.Password.RequireLowercase = true;
                // options.Password.RequireUppercase = true;
                // options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                // options.Lockout.MaxFailedAccessAttempts = 5;
                // options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = true;
            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add Application Context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Razor Pages for Identity
            builder.Services.AddRazorPages();

            // Register the EmailSender Service
            builder.Services.AddTransient<IEmailSender, ConsoleEmailSender>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Add App Authentication for Identity
            app.UseAuthentication();

            app.UseAuthorization();

            // Add Razor Pages for Identity
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
