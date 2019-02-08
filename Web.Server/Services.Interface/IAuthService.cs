using Web.Server.Dtos.AuthData;
using Web.Core.Models.User;

namespace Web.Server.Services.Interface
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthDataDto GetAuthData(User id);
    }
}
