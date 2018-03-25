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
        private TournamentDAO _tournamentDAO;

        public AdminController()
        {
            _userDAO = new UserDAO();
            _tournamentDAO = new TournamentDAO();
        }

        /// <summary>
        /// Method that adds a new player
        /// </summary>
        /// <param name="email">The email of the player</param>
        /// <param name="name">The player name</param>
        /// <param name="password">The password of the player</param>
        public bool AddPlayer(string email, string name, string password)
        {
            if (!IsValidEmail(email))
            {
                return false;
            }
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
                var newPlayer = new User(name, email, password);
                return _userDAO.UpdateUser(newPlayer);
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

        public bool AddTournament(string name)
        {
            return _tournamentDAO.CreateTournament(new Tournament(name));
        }

        public bool FindTournament(string name)
        {
            //return _tournamentDAO.(new Tournament(name));
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
