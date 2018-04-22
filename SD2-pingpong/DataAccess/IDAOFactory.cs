using DataAccess.gamedao;
using DataAccess.matchdao;
using DataAccess.tournamentdao;
using DataAccess.userdao;

namespace DataAccess
{
    public interface IDAOFactory
    {
        IUserDAO CreateUserDao();
        IGameDAO CreateGameDao();
        ITournamentDAO CreateTournamentDao();
        IMatchDAO CreateMatchDao();
    }
}
