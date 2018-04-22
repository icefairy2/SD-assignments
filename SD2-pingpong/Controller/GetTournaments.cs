using System.Collections.Generic;
using Controller;
using DataAccess.tournamentdao;
using Model;

namespace Business
{
    public class GetTournaments
    {
        private ITournamentDAO _tournamentDAO;

        public GetTournaments()
        {
            var connFactory = new ConnectionFactory();
            _tournamentDAO = connFactory.GetTournamentDao();
        }

        public IList<Tournament> GetAll()
        {        
            return _tournamentDAO.FindAllTournaments();
        }

        public Tournament GetByName(string name)
        {
            return _tournamentDAO.FindTourmanentByName(name);
        }
    }
}
