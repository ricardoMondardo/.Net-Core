using System.Security.Claims;
using Web.Repository.Models.User;

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
    }
}
