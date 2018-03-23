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


        public string Execute(string email, string password)
        {

            var user = _userDAO.FindByEmail(email);
            if (user == null)
            {
                return "nonexistent_user";
            }
            if (user.Password != password)
            {
                return "incorrect_password";
            }
            if (user.IsAdmin)
            {
                return "administrator";
            } else
            {
                return "player";
            }
        }
    }
}