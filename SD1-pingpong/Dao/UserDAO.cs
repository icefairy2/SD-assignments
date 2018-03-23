using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Entity;

namespace Dao
{
    public class UserDAO
    {
        private DbConnection _conn;

        public UserDAO()
        {
            _conn = new DbConnection();
        }

        public DataTable FindByName(string userName)
        {
            string query = string.Format("select * from player where name = @userName ");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@userName", SqlDbType.VarChar)
            {
                Value = Convert.ToString(userName)
            };
            return _conn.ExecuteSelectQuery(query, sqlParameters);
        }

        public DataTable FindByEmail(string email)
        {
            string query = string.Format("select * from user where email = @email ");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@email", SqlDbType.VarChar)
            {
                Value = Convert.ToString(email)
            };
            return _conn.ExecuteSelectQuery(query, sqlParameters);
        }

        public bool CreateUser(User user)
        {
            string query = string.Format("insert into user (email, name, password, isAdmin) values (@email, @name, @password, @isAdmin); ");
            var sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@email", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Email)
            };
            sqlParameters[1] = new SqlParameter("@name", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Name)
            };
            sqlParameters[2] = new SqlParameter("@password", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Password)
            };
            sqlParameters[3] = new SqlParameter("@isAdmin", SqlDbType.Bit)
            {
                Value = ((user.IsAdmin)? 1:0)
            };
            return _conn.ExecuteInsertQuery(query, sqlParameters);
        }

        public bool UpdateUser(User user)
        {
            string query = string.Format("update user set name = @name, password = @password, isAdmin = @isAdmin WHERE email = @email; ");
            var sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@name", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Name)
            };
            sqlParameters[1] = new SqlParameter("@password", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Password)
            };
            sqlParameters[2] = new SqlParameter("@isAdmin", SqlDbType.Bit)
            {
                Value = ((user.IsAdmin) ? 1 : 0)
            };
            sqlParameters[3] = new SqlParameter("@email", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Email)
            };
            return _conn.ExecuteDeleteQuery(query, sqlParameters);
        }

        public bool DeleteUser(User user)
        {
            string query = string.Format("delete from user where email = @email ");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@email", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Email)
            };
            return _conn.ExecuteDeleteQuery(query, sqlParameters);
        }
    }
}
