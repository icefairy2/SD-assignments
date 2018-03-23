using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Game
    {
        public int Id { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }

        public Game()
        {
            Score1 = 0;
            Score2 = 0;
        }

        public Game(int score1, int score2)
        {
            Score1 = score1;
            Score2 = score2;
        }
    }
}
