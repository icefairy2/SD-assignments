using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    /// <summary>
    /// Represents the model for the Player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Id of the player
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
    }
}
