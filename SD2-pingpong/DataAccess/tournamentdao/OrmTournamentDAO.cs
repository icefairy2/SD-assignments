using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.orm;
using Model;

namespace DataAccess.tournamentdao
{
    class OrmTournamentDAO : ITournamentDAO
    {
        public bool CreateTournament(Tournament tournament)
        {
            OrmDatabase.Instance.Tournaments.Add(tournament);
            OrmDatabase.Instance.SaveChanges();
            return true;
        }

        public IList<Tournament> FindAllTournaments()
        {
            return OrmDatabase.Instance.Tournaments.ToList();
        }

        public Tournament FindTourmanentByName(string name)
        {
            return OrmDatabase.Instance.Tournaments.FirstOrDefault(trnm => trnm.Name == name);
        }
    }
}
