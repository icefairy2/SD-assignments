using System;
using DataAccess.gamedao;
using DataAccess.matchdao;
using DataAccess.tournamentdao;
using DataAccess.userdao;

namespace DataAccess.orm
{
    public class OrmDAOFactory : IDAOFactory
    {
        public IUserDAO CreateUserDao()
        {
            return new OrmUserDAO();
        }

        public IGameDAO CreateGameDao()
        {
            return new OrmGameDAO();
        }

        public ITournamentDAO CreateTournamentDao()
        {
            return new OrmTournamentDAO();
        }

        public IMatchDAO CreateMatchDao()
        {
            return new OrmMatchDAO();
        }
    }
}
