using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace DataAccess.query
{
    public class DatabaseContext
    {
        private readonly string _connectionstring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        private readonly SQLiteConnection _dbConnection;

        public DatabaseContext()
        {
            _dbConnection = new SQLiteConnection(_connectionstring);
        }

        private bool OpenConnection()
        {
            if (_dbConnection.State == ConnectionState.Closed || _dbConnection.State == ConnectionState.Broken)
            {
                _dbConnection.Open();
            }
            if (_dbConnection.State == ConnectionState.Open)
            {
                return true;
            }
            return false;
        }

        private bool CloseConnection()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }
            if (_dbConnection.State == ConnectionState.Closed)
            {
                return true;
            }
            return false;
        }

        public bool ExecuteQuery(string txtQuery)
        {
            if (OpenConnection())
            {
                var sqlCmd = _dbConnection.CreateCommand();
                sqlCmd.CommandText = txtQuery;
                sqlCmd.ExecuteNonQuery();
                if (CloseConnection())
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
