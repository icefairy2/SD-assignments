using Dao;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CreateMatches
    {
        private MatchDAO matchDao = new MatchDAO();
        private UserDAO userDAO = new UserDAO();

        private static Random rng = new Random();

        public void Shuffle(IList<User> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public bool Execute(Tournament tournament, IList<User> emptyPlayers)
        {
            var players = new List<User>(); 
            foreach (var player in emptyPlayers)
            {
                players.Add(userDAO.FindByName(player.Name));
            }

            Shuffle(players);
            for(int i=0; i<players.Count;i+=2)
            {
                var succeeded = matchDao.CreateMatch(new Match(players.ElementAt(i), players.ElementAt(i+1)), tournament);
                if(!succeeded)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
