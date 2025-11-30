using HelloWorld.Application.Services;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Infrastructure.Services
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        public string GenerateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim("id", user.Id),
                new Claim("userName", user.UserName),
                new Claim("email", user.Email)
            };

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(options.Value.SecretKey));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken securityToken = new(
                issuer: options.Value.Issuer,
                audience: options.Value.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(securityToken);

            return token;
        }
    }
}
