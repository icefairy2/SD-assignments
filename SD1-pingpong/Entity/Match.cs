using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Match
    {
        public int Id { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
        public IList<Game> Games { get; set; }

        public Match()
        {
            Games = new List<Game>();
        }

        public Match(User player1, User player2)
        {
            Player1 = player1;
            Player2 = player2;
            Games = new List<Game>();
        }
    }
}
