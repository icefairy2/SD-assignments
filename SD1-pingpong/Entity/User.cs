using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        /// <summary>
        /// The player name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The password used by the player to login
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The email address of the player
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// True if user has administrator privileges
        /// </summary>
        public bool IsAdmin { get; set; }

        public User()
        {

        }

        public User(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
            IsAdmin = false;
        }

        public User(string name, string password, string email, bool isAdmin) : this(name, password, email)
        {
            IsAdmin = isAdmin;
        }
    }
}
