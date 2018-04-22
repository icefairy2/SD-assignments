using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess.tournamentdao
{
    public interface ITournamentDAO
    {
        bool CreateTournament(Tournament tournament);
        IList<Tournament> FindAllTournaments();
        Tournament FindTourmanentByName(string name);
    }
}
