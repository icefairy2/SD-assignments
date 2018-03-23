using Dao;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Login
    {
        private UserDAO _userDAO;

        public Login()
        {
            _userDAO = new UserDAO();
        }

        public enum UserLoginType
        {
            nonexistent_user = 1,
            incorrect_password = 2,
            administrator = 3,
            player = 4
        }

        public UserLoginType Execute(string email, string password)
        {

            var user = _userDAO.FindByEmail(email);
            if (user == null)
            {
                return UserLoginType.nonexistent_user;
            }
            if (user.Password != password)
            {
                return UserLoginType.incorrect_password;
            }
            if (user.IsAdmin)
            {
                return UserLoginType.administrator;
            } else
            {
                return UserLoginType.player;
            }
        }
    }
}