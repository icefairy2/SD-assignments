using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dao
{
    public class DbConnection
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;
        private string dbConnectionString = "Data Source=DESKTOP-R95RP8R;Initial Catalog=pingpong;Integrated Security=True";

        /// <constructor>
        /// Initialise Connection
        /// </constructor>
        public DbConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(dbConnectionString);
        }

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        private SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State ==
                        ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        /// <method>
        /// Close Database Connection if Open
        /// </method>
        private SqlConnection closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }

        /// <method>
        /// Select Query
        /// </method>
        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " 
                    + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            finally
            {
                myCommand.Connection = closeConnection();
            }
            return dataTable;
        }

        /// <method>
        /// Insert Query
        /// </method>
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " 
                    + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            finally
            {
                myCommand.Connection = closeConnection();
            }
            return true;
        }

        /// <method>
        /// Update Query
        /// </method>
        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: "
                    + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
                myCommand.Connection = closeConnection();
            }
            return true;
        }

        /// <method>
        /// Delete Query
        /// </method>
        public bool executeDeleteQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.DeleteCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeDeleteQuery - Query: "
                    + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
                myCommand.Connection = closeConnection();
            }
            return true;
        }
    }
}
