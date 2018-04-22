using System.Collections.Generic;
using Controller;
using DataAccess.userdao;
using Model;

namespace Business
{
    public class GetPlayers
    {
        private IUserDAO _userDAO;

        public GetPlayers()
        {
            var connFactory = new ConnectionFactory();
            _userDAO = connFactory.GetUserDao();
        }

        public List<User> Execute()
        {
            var userList = _userDAO.FindAllUsers();
            var playerList = new List<User>();
            foreach(var user in userList)
            {
                if (!user.IsAdmin)
                {
                    playerList.Add(user);
                }
            }
            return playerList;
        }
    }
}
