using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ticari.Entities.DBContexts;
using Ticari.WebMVC.Extensions;

namespace Ticari.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SqlDbContext dbContext = new SqlDbContext();
            //dbContext.Database.MigrateAsync().Wait();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            //builder.Services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //});
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddFluentValidationAutoValidation();
            //  builder.Services.AddValidatorsFromAssembly(Assembly.LoadFrom("Ticari.Validation"));
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            // Cors politikasi uygulanacak
            #region Enable Cors => Yolgeçen hani

            builder.Services.AddCors(p =>
                 p.AddDefaultPolicy(
                     b => b.AllowAnyHeader()
                         .AllowAnyOrigin() // Gelen Butun Requestler'e izin veriri
                         .AllowAnyMethod())
             //.AllowCredentials()                  

             );

            #region Eger Belirli doman'lere izin verilecek ise yapilmasi gerekn ayarlar asagidadir
            // builder.Services.AddCors(p =>
            //    p.AddPolicy("myClient",b=>
            //    b.WithOrigins("http://localhost:5248", "http://localhost:46399")) 

            //); 
            #endregion

            #endregion
            #region DbContext Registiration
            var constr = builder.Configuration.GetConnectionString("Ticari");
            var turkiyeConStr = builder.Configuration.GetConnectionString("TurkiyeDb");
            builder.Services.AddDbContext<SQLDbContext>(options => options.UseSqlServer(constr));
            builder.Services.AddDbContext<TurkiyeContext>(options => options.UseSqlServer(turkiyeConStr));
            #endregion

            builder.Services.AddTicariService();

            #region Service Authentication Ayarlarini eklenemsi
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = true,//Sadece Buradaki kullanicilar tarafindan kullailabilir
                       ValidateIssuer = true, // Toke'i olustuan veya yayinlayicinin adi
                       ValidateLifetime = true, // Token degerinin kullanim suresinin dogrulanmasi aktif hale getirir
                       ValidateIssuerSigningKey = true,//Token degerinin bu uygulamaya ait olup olmadigini anlamamizi saglayan security key dogrulamasini aktiflestiriyoruz
                       ValidIssuer = builder.Configuration.GetSection("ApiConfig:issuer").Value, //Web Apimizin calisan adresini yaziyoruz
                       ValidAudience = builder.Configuration.GetSection("ApiConfig:audience").Value,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("ApiConfig:ApiPassword").Value)),
                       ClockSkew = TimeSpan.Zero

                   });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}