using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class PlayerDAO
    {
        private readonly string GetAllPlayersSql = "select * from player";


        public Player Find(string email)
        {
            //todo: logic
            Database.Connect();
            var rdr = Database.ExecuteQuery(GetAllPlayersSql);

            var allPlayers = new List<Player>();

            while (rdr.Read())
            {
                var player = new Player();
                player.Id = rdr.GetInt32(rdr.GetOrdinal("id")); //The 0 stands for "the 0'th column", so the first column of the result.
                                                                // Do somthing with this rows string, for example to put them in to a list
                player.Name = rdr.GetString(rdr.GetOrdinal("name"));
                player.Password = rdr.GetString(rdr.GetOrdinal("password"));
                player.Email = rdr.GetString(rdr.GetOrdinal("email"));

                allPlayers.Add(player);
            }

            var foundPlayer = allPlayers
                .Select(player => player)
                .Where(player => player.Email == email);

            Database.Disconnect();
            return foundPlayer.First();

        }
    }
}
