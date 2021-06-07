using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LisBank.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LisBank.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(DateTime expirationDate, string username, string idUser)
        {
            return GenerateToken(_configuration["Authentication:SecretKey"], expirationDate, username, idUser);
        }

        public string GenerateRefreshToken(DateTime expirationDate, string username, string idUser)
        {
            return GenerateToken(_configuration["Authentication:RefreshKey"], expirationDate, username, idUser);
        }

        public (string,string) RefreshToken(string refreshToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Authentication:Issuer"],
                ValidAudience = _configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:RefreshKey"])),
            };
            try
            {
                jwtTokenHandler.ValidateToken(refreshToken, jwtValidationParameters, out SecurityToken validatedToken);
            }
            catch(Exception ex)
            {
                throw new Exception("Invalid token.");
            }
            var jwtRefresh = jwtTokenHandler.ReadJwtToken(refreshToken);
            var username = jwtRefresh.Claims.Where(claim => claim.Type == ClaimTypes.Name).FirstOrDefault().Value;
            var id = jwtRefresh.Claims.Where(claim => claim.Type == "id").FirstOrDefault().Value;
            var type = jwtRefresh.Claims.Where(claim => claim.Type == "type").FirstOrDefault().Value;
            var accessToken = GenerateAccessToken(DateTime.UtcNow.AddDays(1), username, id);
            refreshToken = GenerateRefreshToken(DateTime.UtcNow.AddDays(3),username, id);

            return (accessToken, refreshToken);
        }

        private string GenerateToken(string key, DateTime expirationDate, string username, string idUser)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("id", idUser),
            };
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                expirationDate
            );
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
