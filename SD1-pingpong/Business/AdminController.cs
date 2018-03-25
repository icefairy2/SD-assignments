using Dao;
using Entity;

namespace Business
{
    /// <summary>
    /// Class that handles all admin operations
    /// </summary>
    public class AdminController
    {
        private UserDAO _userDAO;

        public AdminController()
        {
            _userDAO = new UserDAO();
        }

        /// <summary>
        /// Method that adds a new player
        /// </summary>
        /// <param name="email">The email of the player</param>
        /// <param name="name">The player name</param>
        /// <param name="password">The password of the player</param>
        public bool AddPlayer(string email, string name, string password)
        {
            var player = new User(name, email, password, false);
            var userDAO = new UserDAO();
            return userDAO.CreateUser(player);
        }

        /// <summary>
        /// Method that updates an existing player (email exists in database)
        /// </summary>
        /// <param name="email">The email of the player</param>
        /// <param name="name">The (new) player name</param>
        /// <param name="password">The (new) password of the player</param>
        public bool UpdatePlayer(string email, string name, string password)
        {
            var player = _userDAO.FindByEmail(email);
            if (player != null)
            {
                return _userDAO.UpdateUser(player);
            }
            return false;
        }

        /// <summary>
        /// Method that deletes an existing player (email exists in database)
        /// </summary>
        /// <param name="email">The email of the player</param>
        /// <param name="name">The player name</param>
        /// <param name="password">The password of the player</param>
        public bool DeletePlayer(string email, string name, string password)
        {
            var player = _userDAO.FindByEmail(email);
            if (player != null)
            {
                return _userDAO.DeleteUser(player);
            }
            return false;
        }

        /// <summary>
        /// Method that returns data of an existing player first which has this name
        /// </summary>
        /// <param name="name">The name of the player</param>
        public User FindByName(string name)
        {
            return _userDAO.FindByName(name);
        }

        /// <summary>
        /// Method that returns data of an existing player (email exists in database)
        /// </summary>
        /// <param name="email">The email of the player</param>
        public User FindByEmail(string email)
        {
            return _userDAO.FindByEmail(email);
        }
    }
}
