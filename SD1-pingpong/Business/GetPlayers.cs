using Dao;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GetPlayers
    {
        private UserDAO _userDAO;

        public List<User> Execute()
        {
            _userDAO = new UserDAO();
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
