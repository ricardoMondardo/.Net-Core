using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CryptoHelper;
using Microsoft.IdentityModel.Tokens;
using Web.Server.Dtos.AuthData;
using Web.Server.Services.Interface;
using Web.Repository.Models.User;

namespace Web.Server.Services
{
    public class AuthService : IAuthService
    {
        readonly string _jwtSecret;
        readonly int _jwtLifespan;
        public AuthService(string jwtSecret, int jwtLifespan)
        {
            this._jwtSecret = jwtSecret;
            this._jwtLifespan = jwtLifespan;
        }
        public AuthDataDto GetAuthData(User user)
        {
            var expirationTime = DateTime.Now.AddMinutes(_jwtLifespan);
            //var expirationTime = DateTime.UtcNow.AddSeconds(_jwtLifespan);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var tokeOptions = new JwtSecurityToken(
                     issuer: "http://localhost:5000",
                     audience: "http://localhost:5000",
                     claims: new List<Claim>() {
                         new Claim(ClaimTypes.NameIdentifier, user.Id),
                         new Claim(ClaimTypes.Name, user.UserName)
                     },
                     expires: expirationTime,
                     signingCredentials: signingCredentials
                 );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return new AuthDataDto
            {
                Token = tokenString,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = user.Id
            };
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}