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
    public class MatchDAO
    {
        private UserDAO _userDAO;
        private GameDAO _gameDAO;

        public MatchDAO()
        {
            _userDAO = new UserDAO();
            _gameDAO = new GameDAO();
        }

        public List<Match> FindAllMatches()
        {
            string query = string.Format("select * from dbo.Match;");

            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectAllQuery(query);
            var matchList = new List<Match>();
            int idPlayer1, idPlayer2;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var match = new Match();
                    match.Id = (int)reader["id"];
                    match.Time = (DateTime)reader["time"];
                    idPlayer1 = (int)reader["player1"];
                    //match.Player1 = _userDAO.FindById(idPlayer1);
                    idPlayer2 = (int)reader["player2"];
                    match.Player2 = _userDAO.FindById(idPlayer2);
                    //match.Games = _gameDAO.FindAllMatchGames(match);
                    matchList.Add(match);
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                return null;
            }
            return matchList;

        }

        public List<Match> FindAllTournamentMatches(Tournament tournament)
        {
            string query = string.Format("select * from dbo.Match where tournament = @tournament");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = tournament.Id
            };

            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectQuery(query, sqlParameters);
            var matchList = new List<Match>();
            int idPlayer1, idPlayer2;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var match = new Match();
                    match.Id = (int)reader["id"];
                    match.Time = (DateTime)reader["time"];
                    idPlayer1 = (int)reader["player1"];
                    //match.Player1 = _userDAO.FindById(idPlayer1);
                    idPlayer2 = (int)reader["player2"];
                    match.Player2 = _userDAO.FindById(idPlayer2);
                    //var matchGameList = _gameDAO.FindAllMatchGames(match);
                    matchList.Add(match);
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                return null;
            }
            return matchList;

        }

        public bool CreateMatch(Match match, User player1, User player2, Tournament tournament)
        {
            string query = string.Format("insert into dbo.Match (time, player1, player2, tournament) values (@time, @player1, @player2, @tournament); ");
            var sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@time", SqlDbType.VarChar)
            {
                Value = match.Time
            };
            sqlParameters[1] = new SqlParameter("@player1", SqlDbType.VarChar)
            {
                Value = player1.Id
            };
            sqlParameters[2] = new SqlParameter("@player2", SqlDbType.VarChar)
            {
                Value = player2.Id
            };
            sqlParameters[3] = new SqlParameter("@tournament", SqlDbType.VarChar)
            {
                Value = tournament.Id
            };
            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }

            return false;
        }

        public bool UpdateMatch(Match match)
        {
            string query = string.Format("update dbo.Match set time = @time WHERE id = @id; ");
            var sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@time", SqlDbType.VarChar)
            {
                Value = match.Time
            };
            sqlParameters[1] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = match.Id
            };

            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }

            return false;
        }

        public bool DeleteMatch(Match match)
        {
            string query = string.Format("delete from dbo.Match where id = @id ");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = match.Id
            };
            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }

            return false;
        }
    }
}
