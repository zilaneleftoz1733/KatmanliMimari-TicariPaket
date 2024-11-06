
using Microsoft.EntityFrameworkCore;
using Ticari.Api.Extensions;
using Ticari.Entities.DBContexts;

namespace Ticari.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
            // Cors politikasi uygulanacak
            #region Enable Cors
            builder.Services.AddCors(p =>
                p.AddDefaultPolicy(
                    b => b.AllowAnyHeader()
                        .AllowAnyOrigin() // Gelen Butun Requestler'e izin veriri
                        .AllowAnyMethod()) // 

            );

            builder.Services.AddCors(p =>
               p.AddPolicy("myClient", b =>
               b.WithOrigins("http://localhost:5248", "http://localhost:46399"))

           );

            #endregion
            #region DbContext Registiration
            var constr = builder.Configuration.GetConnectionString("Ticari");
            var turkiyeConStr = builder.Configuration.GetConnectionString("TurkiyeDb");
            builder.Services.AddDbContext<SQLDbContext>(options => options.UseSqlServer(constr));
            builder.Services.AddDbContext<TurkiyeContext>(options => options.UseSqlServer(turkiyeConStr));
            #endregion

            builder.Services.AddTicariService();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
