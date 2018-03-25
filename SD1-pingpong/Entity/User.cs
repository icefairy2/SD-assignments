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
        /// The id of the player in the database
        /// </summary>
        public int Id { get; set; }

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

        public User(string name, string email, string password)
        {
            Name = name;
            Password = password;
            Email = email;
            IsAdmin = false;
        }

        public User(string name, string email, string password, bool isAdmin) : this(name, email, password)
        {
            IsAdmin = isAdmin;
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   Id == user.Id;
        }
    }
}
