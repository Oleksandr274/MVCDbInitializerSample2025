using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tracker.WebAPIClient;
using Week1Lab12026.Models;

namespace Week1Lab12026
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ActivityAPIClient.Track(
                StudentID: "S00274217",
                StudentName: "Oleksandr Keshel",
                activityName: "Rad302 2026 Week 1 Lab 1",
                Task: "Creating controllers and Views"
            );

            var builder = WebApplication.CreateBuilder(args);

            //retrieve connection string from appsettings.json 
            var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            //create the UserContext with the connection string
            builder.Services.AddDbContext<UserContext>(options =>
                //new target assembly directive for migrations
                options.UseSqlServer(dbConnectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //retrieve user context from the services container
            using( var scope = app.Services.CreateScope())
            {
                var _ctx = scope.ServiceProvider.GetRequiredService<UserContext>();
                //retrieve the IWebHostEnvironment for the Content Root (even though we are not using the file system here)
                var hostEnvironment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
                // seed data from DbSeeder class
                DbSeeder dbSeeder = new DbSeeder(_ctx, hostEnvironment);
                dbSeeder.Seed();
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
