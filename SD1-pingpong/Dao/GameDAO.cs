using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class GameDAO
    { 

        public List<Game> FindAllGames()
        {
            string query = string.Format("select * from dbo.Game;");
            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectAllQuery(query);
            var gameList = new List<Game>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var game = new Game
                    {
                        Id = (int)reader["id"],
                        Score1 = (int)reader["score1"],
                        Score2 = (int)reader["score2"]
                    };
                    gameList.Add(game);
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                return null;
            }
            return gameList;
        }

        public List<Game> FindAllMatchGames(Match match)
        {
            string query = string.Format("select * from dbo.Game where match = @match");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = match.Id
            };
            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectQuery(query, sqlParameters);
            var gameList = new List<Game>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var game = new Game
                    {
                        Id = (int)reader["id"],
                        Score1 = (int)reader["score1"],
                        Score2 = (int)reader["score2"]
                    };
                    gameList.Add(game);
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                return null;
            }
            return gameList;
        }

        public bool CreateGame(Game game, Match match)
        {
            string query = string.Format("insert into dbo.Game (score1, score2, match) values (@score1, @score2, @match); ");
            var sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@score1", SqlDbType.VarChar)
            {
                Value = game.Score1
            };
            sqlParameters[1] = new SqlParameter("@score2", SqlDbType.VarChar)
            {
                Value = game.Score2
            };
            sqlParameters[2] = new SqlParameter("@match", SqlDbType.VarChar)
            {
                Value = match.Id
            };
            return DbConnection.ConnectionInstance.ExecuteInsertQuery(query, sqlParameters);
        }

        public bool UpdateGame(Game game)
        {
            string query = string.Format("update dbo.Game set score1 = @score1, score2 = @score2 WHERE id = @id; ");
            var sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = game.Id
            };
            sqlParameters[1] = new SqlParameter("@score1", SqlDbType.VarChar)
            {
                Value = game.Score1
            };
            sqlParameters[2] = new SqlParameter("@score2", SqlDbType.VarChar)
            {
                Value = game.Score2
            };
            return DbConnection.ConnectionInstance.ExecuteDeleteQuery(query, sqlParameters);
        }

        public bool DeleteGame(Game game)
        {
            string query = string.Format("delete from dbo.Game where id = @id ");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = game.Id
            };
            return DbConnection.ConnectionInstance.ExecuteDeleteQuery(query, sqlParameters);
        }
    }
}
