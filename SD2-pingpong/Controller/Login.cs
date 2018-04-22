using Controller;
using DataAccess.userdao;
using Model;

namespace Business
{
    public class Login
    {
        private IUserDAO _userDAO;
        public static User LoggedInUser;

        public Login()
        {
            var connFactory = new ConnectionFactory();
            _userDAO = connFactory.GetUserDao();
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
                LoggedInUser = user;
                return UserLoginType.administrator;
            } else
            {
                LoggedInUser = user;
                return UserLoginType.player;
            }
        }
    }
}