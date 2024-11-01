using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Ticari.Entities.DBContexts;
using Ticari.WebMVC.Extensions;
using Ticari.WebMVC.MyProfile;

namespace Ticari.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation(); // Burasini eklemeyi unutmusuz

            #region DbContext Registiration
            var constr = builder.Configuration.GetConnectionString("Ticari");
            builder.Services.AddDbContext<SQLDbContext>(options => options.UseSqlServer(constr));
            #endregion
            builder.Services.AddAutoMapper(p => p.AddProfile<AutoMapperProfile>());


            #region Notify Service Configuration
            builder.Services.AddNotyf(p =>
            {
                p.Position = NotyfPosition.BottomRight;
                p.DurationInSeconds = 7;
                p.IsDismissable = true;

            });
            #endregion

            #region Cookie Base Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "IstkaFullData";
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.AccessDeniedPath = "/Account/ErisimHatasi";
                    options.Cookie.HttpOnly = true; // Tarayicidaki diger scriptler okuyamasin
                    options.Cookie.SameSite = SameSiteMode.Strict;//Baþka tarayicilar tarafindan ulasilamasin
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                    options.SlidingExpiration = true;//Sitede herhangi bir hareket oldugunda sureyi 10 dakika uzatir

                });
            #endregion

            builder.Services.AddTicariService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseNotyf();
            app.UseRouting();

            app.UseAuthentication(); //Burada ki siralama onemli
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            //TODO : Rota Tanimlamasina bakilacak
            //app.MapControllerRoute(

            //   name: "login",
            //    pattern: "login",
            //    defaults: new { controller = "Account", action = "Login" });

            app.MapControllerRoute(

                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );



            app.Run();
        }
    }
}