using Microsoft.AspNetCore.Mvc;
using Ticari.Api.Model;
using Ticari.Entities.DBContexts;
using Microsoft.AspNetCore.Http;

namespace Ticari.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController(SQLDbContext dbContext, IConfiguration configuration) : ControllerBase
    {

        [HttpGet]
        public async Task<IResult> Login(string email, string password)
        {
            var user = dbContext.Users.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
            if (user != null)
            {
                TokenManager tokenManager = new TokenManager();
                Token token = await tokenManager.CreateAccessToken(user, configuration);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expration;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return Results.Ok(token);
            }
            return Results.NotFound();
        }

        [HttpPost]
        public async Task<IResult> Login2(string email, string password)
        {
            var user = dbContext.Users.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
            if (user != null)
            {
                TokenManager tokenManager = new TokenManager();
                Token token = await tokenManager.CreateAccessToken(user, configuration);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expration;
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return Results.Ok(token);
            }
            return Results.NotFound();
        }

    }
}
