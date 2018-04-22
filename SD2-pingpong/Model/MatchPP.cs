using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MatchPP
    {
        public int Id { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
        public IList<Game> Games { get; set; }
        public Tournament Tournament { get; set; }

        public MatchPP()
        {
            Games = new List<Game>();
        }

        public MatchPP(User player1, User player2)
        {
            Player1 = player1;
            Player2 = player2;
            Games = new List<Game>();
        }
    }
}
