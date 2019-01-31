using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CryptoHelper;
using Microsoft.IdentityModel.Tokens;
using Web.Api.Dtos.AuthData;
using Web.Api.Services.Interface;

namespace Web.Api.Services
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
        public AuthDataDto GetAuthData(string id)
        {
            var expirationTime = DateTime.Now.AddMinutes(_jwtLifespan);
            //var expirationTime = DateTime.UtcNow.AddSeconds(_jwtLifespan);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var tokeOptions = new JwtSecurityToken(
                     issuer: "http://localhost:5000",
                     audience: "http://localhost:5000",
                     claims: new List<Claim>() {
                         new Claim(ClaimTypes.NameIdentifier, id),
                     },
                     expires: expirationTime,
                     signingCredentials: signingCredentials
                 );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return new AuthDataDto
            {
                Token = tokenString,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = id
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