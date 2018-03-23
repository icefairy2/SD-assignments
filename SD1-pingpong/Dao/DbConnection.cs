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
        private SqlConnection conn;
        private string dbConnectionString = "Data Source=DESKTOP-R95RP8R;Initial Catalog=pingpong;Integrated Security=True";

        public static DbConnection ConnectionInstance = new DbConnection();

        /// <summary>
        /// Initialise Connection
        /// </summary>
        public DbConnection()
        {
            conn = new SqlConnection(dbConnectionString);
        }

        /// <summary>
        /// Open database connection if closed
        /// </summary>
        /// <returns>The sqlconnection object</returns>
        internal SqlConnection OpenConnection()
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
        internal SqlConnection CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
        
        /// <summary>
        /// Method for executing a query
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>A sqlreader result</returns>
        public SqlDataReader ExecuteSelectQuery(String query, SqlParameter[] sqlParameter)
        {
            var myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                SqlDataReader reader = myCommand.ExecuteReader();
                return reader;
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: "
                    + query + " \nException: " + e.StackTrace.ToString());
                return null;
            }            
        }

        public SqlDataReader ExecuteSelectAllQuery(String query)
        {
            var myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                SqlDataReader reader = myCommand.ExecuteReader();
                return reader;
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: "
                    + query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
        }

        public bool ExecuteInsertQuery(String query, SqlParameter[] sqlParameter)
        {
            var myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " 
                    + query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            return true;
        }

        public bool ExecuteUpdateQuery(String query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: "
                    + query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            return true;
        }

        public bool ExecuteDeleteQuery(String query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeDeleteQuery - Query: "
                    + query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            return true;
        }
    }
}
