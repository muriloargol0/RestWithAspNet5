using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithAspNet.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> Claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
