using Dao;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SaveScore
    {
        private GameDAO _gameDao;

        public SaveScore()
        {
            _gameDao = new GameDAO();
        }

        public enum ScoreResponeType
        {
            nonnumeric = 1,
            too_big_values = 2,
            player1_won = 3,
            player2_won = 4
        }

        public ScoreResponeType Execute(Match match, string score1String, string score2String)
        {
            int score1, score2;

            if (Int32.TryParse(score1String, out score1))
            {
                if (Int32.TryParse(score2String, out score2))
                {
                    if (score1 + score2 > 5)
                    {
                        return ScoreResponeType.too_big_values;
                    }
                    else
                    {
                        var newGame = new Game(score1, score2);
                        _gameDao.CreateGame(newGame, match);
                        if (score1 > score2)
                        {
                            return ScoreResponeType.player1_won;
                        }
                        return ScoreResponeType.player2_won;
                    }
                } else
                {
                    return ScoreResponeType.nonnumeric;
                }
            } else
            {
                return ScoreResponeType.nonnumeric;
            }
        }
    }
}
