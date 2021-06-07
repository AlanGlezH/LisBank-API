using System;
using System.Threading.Tasks;

namespace LisBank.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(DateTime expirationDate, string username, string idUser);
        string GenerateRefreshToken(DateTime expirationDate, string username, string idUser);
        (string accesToken,  string refreshToken) RefreshToken(string refreshToken);
    }
}
