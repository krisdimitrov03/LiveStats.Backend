using LiveStats.Core.Identity.Contracts;
using LiveStats.Core.Identity.Data.Models.Input;
using LiveStats.Core.Identity.Data.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Identity.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateToken(TokenData data, JwtSettings settings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(settings.Secret);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", data.UserId),
                    new Claim("username", data.Username),
                    new Claim("roles", data.Roles),
                    new Claim("imageUrl", data.ImageUrl)
                }),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
