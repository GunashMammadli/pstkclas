using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PustokMVC.Context;
using PustokMVC.Helpers;

namespace PustokMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PustokDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration["ConnectionStrings:MsSql"]);
            });
            PathConstants.RootPath = builder.Environment.WebRootPath;

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Slider}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}