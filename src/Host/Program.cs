using TechMarket.BLL.Services;
using TechMarket.BLL.Interfaces;
using TechMarket.DAL.Interfaces;
using TechMarket.DAL.Repositories;
using TechMarket.BLL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TechMarket.DAL.EF;
using TechMarket.DAL.Entities;

namespace TechMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                                        
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            //        options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationContext>();

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddAutoMapper(typeof(DTOMappingProfile), typeof(ViewModelMappingProfile));

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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}