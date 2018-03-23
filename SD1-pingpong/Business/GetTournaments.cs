using Dao;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GetTournaments
    {
        private TournamentDAO _tournamentDAO;

        public List<Tournament> Execute()
        {
            _tournamentDAO = new TournamentDAO();
            return _tournamentDAO.FindAllTournaments();
        }
    }
}
