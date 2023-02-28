using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Udemy.JwtApp.Api.Core.Application.Dto;

namespace Udemy.JwtApp.Api.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {

        public static TokenResponseDto GenereateToken(CheckUserResponseDto dto)
        {

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(dto.UserRole))
                claims.Add(new Claim(ClaimTypes.Role, dto.UserRole));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.UserId.ToString()));

            if (!string.IsNullOrEmpty(dto.UserName))
                claims.Add(new Claim(ClaimTypes.Name , dto.UserName));

           var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            SigningCredentials credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);


            var expiredate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            JwtSecurityToken  jwtSecurityToken = new JwtSecurityToken
             (
                issuer: JwtTokenDefaults.ValidIssuer,
                audience:JwtTokenDefaults.ValidAudience,
                claims:claims,
                notBefore: DateTime.UtcNow,    
                expires: expiredate,
                signingCredentials: credentials
             );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            // handler.WriteToken();
            return new  TokenResponseDto(handler.WriteToken(jwtSecurityToken), expiredate);
        }

    }
}
