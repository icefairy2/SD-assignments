using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public static class Database
    {
        private static SQLiteConnection m_dbConnection;

        public static void Connect()
        {
           m_dbConnection = new SQLiteConnection(@"Data Source=testdb.db;Version=3;");
        }

        public static void Disconnect()
        {
            m_dbConnection.Close();
        }

        public static SQLiteDataReader ExecuteQuery( string query)
        {
            
            m_dbConnection.Open();

            string sql = query;

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            var reader = command.ExecuteReader();
            //m_dbConnection.Close();

            return reader;
        }
    }
}
