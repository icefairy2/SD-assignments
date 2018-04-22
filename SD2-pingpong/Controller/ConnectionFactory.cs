using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.gamedao;
using DataAccess.matchdao;
using DataAccess.orm;
using DataAccess.tournamentdao;
using DataAccess.userdao;

namespace Controller
{
    public class ConnectionFactory
    {
        private string _connectionType;
        private IDAOFactory _daoFactory;

        public ConnectionFactory()
        {
            _connectionType = ConfigurationManager.AppSettings.Get("SystemDAL");
            InitDao();
        }

        private void InitDao()
        {
            switch (_connectionType)
            {
                case "EntityFramework":
                    _daoFactory = new OrmDAOFactory();
                    break;
                case "SqLiteQueries":
                    break;
                default:
                    break;
            }
        }

        public IUserDAO GetUserDao()
        {
            return _daoFactory.CreateUserDao();
        }

        public IGameDAO GetGameDao()
        {
            return _daoFactory.CreateGameDao();
        }

        public IMatchDAO GetMatchDao()
        {
            return _daoFactory.CreateMatchDao();
        }

        public ITournamentDAO GetTournamentDao()
        {
            return _daoFactory.CreateTournamentDao();
        }

    }
}
