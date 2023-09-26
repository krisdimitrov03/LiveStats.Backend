using LiveStats.Core.Identity.Data.Models.Input;
using LiveStats.Core.Identity.Data.Settings;

namespace LiveStats.Core.Identity.Contracts
{
    public interface IJwtService
    {
        string GenerateToken(TokenData data, JwtSettings settings);
    }
}
