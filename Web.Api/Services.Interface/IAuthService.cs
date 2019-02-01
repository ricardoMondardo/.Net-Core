using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Dtos.AuthData;
using Web.Repository.Models.User;

namespace Web.Api.Services.Interface
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthDataDto GetAuthData(User id);
    }
}
