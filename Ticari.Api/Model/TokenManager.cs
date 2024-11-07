﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Ticari.Entities.Entities.Concrete;

namespace Ticari.Api.Model
{
    public class TokenManager
    {

        public async Task<Token> CreateAccessToken(MyUser user)
        {
            Token token = new Token();
            token.Expration = DateTime.Now.AddMinutes(30);

            List<Claim> claims = new List<Claim>()
         {
             new Claim(ClaimTypes.Role,"Admin"),
             new Claim(ClaimTypes.Email,user.Email),
             new Claim("Ulke","Turkiye"),
             new Claim("BanaOlanBoruc","1000"),
             new Claim("TcNo","123123123"),
             new Claim(ClaimTypes.Name,user.Ad)
         };



            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Benim Super Sifrem 123qweasd!!"));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: "https://localhost:7022", //Bu token i kim uretti
                audience: "https://localhost:7022",//Bu token kimler tarafindan kullanilacak
                expires: token.Expration,
                notBefore: DateTime.Now,// Bu token uretildikten ne kadar sure sonra devreye girsin
                signingCredentials: signingCredentials,
                claims: claims

                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            token.AccessToken = handler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
    public class Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expration { get; set; }
    }
}

