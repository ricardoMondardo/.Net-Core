using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Services.Interface;
using Web.Repository.Interfaces;
using Web.Repository.Models.User;

namespace Web.Api.Services
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

        public User GetSingle(string email)
        {
            return _unitOfWork.Users.Find(u => u.Email == email).FirstOrDefault();
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
