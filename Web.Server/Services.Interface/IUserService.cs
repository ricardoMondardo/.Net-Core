using System.Security.Claims;
using Web.Core.Models.User;

namespace Web.Server.Services.Interface
{
    public interface IUserService
    {
        void Add(User user);
        bool IsEmailUniq(string email);
        bool IsUsernameUniq(string username);
        User GetSingle(string email);
        User Get(string Id);
        string GetContextUserId(ClaimsPrincipal userClaims);
        bool ActiveUser(string email, string token);
    }
}
