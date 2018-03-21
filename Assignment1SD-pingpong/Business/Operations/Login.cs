
using Dao;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operations
{
    public class Login
    {
        public Player Execute()
        {
            var playerDAO = new PlayerDAO();
            var player = playerDAO.Find("aaa@aaa");
            return player;
        }
    }
}
