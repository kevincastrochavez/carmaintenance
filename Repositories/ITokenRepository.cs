using Microsoft.AspNetCore.Identity;

namespace CarMaintenance.Data;

public interface ITokenRepository
{
    string CreateJwtToken(IdentityUser user);
}