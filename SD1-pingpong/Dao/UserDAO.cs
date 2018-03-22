using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Dao
{
    public class UserDAO
    {
        private DbConnection conn;

        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public UserDAO()
        {
            conn = new DbConnection();
        }

        /// <method>
        /// Get User Email By Firstname or Lastname and return DataTable
        /// </method>
        public DataTable searchByName(string _username)
        {
            string query = string.Format("select * from [t01_user] where t01_firstname like @t01_firstname or t01_lastname like @t01_lastname ");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@t01_firstname", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_username);
            sqlParameters[1] = new SqlParameter("@t01_lastname", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(_username);
            return conn.executeSelectQuery(query, sqlParameters);
        }

        /// <method>
        /// Get User Email By Id and return DataTable
        /// </method>
        public DataTable searchById(string _id)
        {
            string query = "select * from [t01_id] where t01_id = @t01_id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@t01_id", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(_id);
            return conn.executeSelectQuery(query, sqlParameters);
        }
    }
}
