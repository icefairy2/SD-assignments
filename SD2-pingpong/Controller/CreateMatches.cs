using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Controller;
using DataAccess.matchdao;
using DataAccess.userdao;
using Model;

namespace Business
{
    public class CreateMatches
    {
        private IMatchDAO _matchDao;
        private IUserDAO _userDAO;

        private static Random rng = new Random();

        public CreateMatches()
        {
            var connFactory = new ConnectionFactory();
            _matchDao = connFactory.GetMatchDao();
            _userDAO = connFactory.GetUserDao();
        }

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
                players.Add(_userDAO.FindByName(player.Name));
            }

            Shuffle(players);
            /*for(int i=0; i<players.Count;i+=2)
            {
                var succeeded = _matchDao.CreateMatch(new Match(players.ElementAt(i), players.ElementAt(i+1)), tournament);
                if(!succeeded)
                {
                    return false;
                }
            }*/
            return true;
        }

    }
}
