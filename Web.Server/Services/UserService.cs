using System.Linq;
using System.Security.Claims;
using Web.Server.Services.Interface;
using Web.Core.Interfaces;
using Web.Core.Models.User;
using System;

namespace Web.Server.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
        }

        public User Get(string id)
        {
            return _unitOfWork.Users.Get(id);
        }

        public bool UpdateActiveCode(string email)
        {
            var user = GetSingle(email);

            if (user == null) return false;

            user.ActiveCode = Guid.NewGuid().ToString();
            _unitOfWork.Save();

            return true;                    

        }

        public bool ActiveUser(string email, string token)
        {
            var user = GetSingle(email);

            if (user == null) return false;

            if (user.ActiveCode == token)
            {
                user.Active = true;                
            } else {
                user.Active = false;
                user.ActiveCode = Guid.NewGuid().ToString();
            }

            _unitOfWork.Save();

            return user.Active;
        }

        public User GetSingle(string email)
        {
            return _unitOfWork.Users.Find(u => u.Email == email).FirstOrDefault();
        }

        public string GetContextUserId(ClaimsPrincipal userClaims)
        {
            return userClaims.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public bool IsEmailUniq(string email)
        {
            return GetSingle(email) == null;
        }

        public bool IsUsernameUniq(string username)
        {
            return _unitOfWork.Users.Find(u => u.UserName == username).FirstOrDefault() == null;
        }
    }
}
