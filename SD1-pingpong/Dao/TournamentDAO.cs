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
    public class TournamentDAO
    {
        private MatchDAO _matchDAO;

        public TournamentDAO()
        {
            _matchDAO = new MatchDAO();
        }

        public List<Tournament> FindAllTournaments()
        {

            string query = string.Format("select * from dbo.Tournament;");
            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectAllQuery(query);
            var tournamentList = new List<Tournament>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var tournament = new Tournament
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString(),
                        Status = reader["status"].ToString()
                    };
                    //tournament.Matches = _matchDAO.FindAllTournamentMatches(tournament);
                    tournamentList.Add(tournament);
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                return null;
            }
            return tournamentList;

        }

        public bool CreateTournament(Tournament tournament)
        {
            string query = string.Format("insert into dbo.Tournament (name, status) values (@name, @status); ");
            var sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@name", SqlDbType.VarChar)
            {
                Value = tournament.Name
            };
            sqlParameters[1] = new SqlParameter("@status", SqlDbType.VarChar)
            {
                Value = tournament.Status
            };
            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }

            return false;
        }

        public bool UpdateTournament(Tournament tournament)
        {
            string query = string.Format("update dbo.Tournament set name = @name, status = @status WHERE id = @id; ");
            var sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = tournament.Id
            };
            sqlParameters[1] = new SqlParameter("@name", SqlDbType.VarChar)
            {
                Value = tournament.Name
            };
            sqlParameters[2] = new SqlParameter("@status", SqlDbType.VarChar)
            {
                Value = tournament.Status
            };
            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }

            return false;
        }

        public bool DeleteTournament(Tournament Tournament)
        {
            string query = string.Format("delete from dbo.Tournament where id = @id ");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = Tournament.Id
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
