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

        public User FindById(int id)
        {
            string query = string.Format("select * from dbo.Player where id = @id");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.VarChar)
            {
                Value = id
            };

            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectQuery(query, sqlParameters);
            var user = new User();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    user.Id = (int)reader["id"];
                    user.Email = (string)reader["email"];
                    user.Name = (string)reader["name"];
                    user.Password = (string)reader["password"];
                    user.IsAdmin = (bool)reader["isAdmin"];
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return null;
            }
            return user;

        }

        public User FindByName(string userName)
        {
            string query = string.Format("select * from dbo.Users where [name] = @name;");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@name", SqlDbType.VarChar)
            {
                Value = Convert.ToString(userName)
            };

            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectQuery(query, sqlParameters);
            var user = new User();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    user.Id = (int)reader["id"];
                    user.Email = (string)reader["email"];
                    user.Name = (string)reader["name"];
                    user.Password = (string)reader["password"];
                    user.IsAdmin = (bool)reader["isAdmin"];
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return null;
            }
            return user;

        }

        public User FindByEmail(string email)
        {
            string query = string.Format("select * from dbo.Users where [email] = @email");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@email", SqlDbType.VarChar)
            {
                Value = Convert.ToString(email)
            };

            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectQuery(query, sqlParameters);
            var user = new User();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.Id = (int)reader["id"];
                    user.Email = reader["email"].ToString();
                    user.Name = reader["name"].ToString();
                    user.Password = reader["password"].ToString();
                    user.IsAdmin = (bool)reader["isAdmin"];
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return null;
            }
            return user;

        }

        public List<User> FindAllUsers()
        {
            string query = string.Format("select * from dbo.Users;");
            SqlDataReader reader = DbConnection.ConnectionInstance.ExecuteSelectAllQuery(query);
            var userList = new List<User>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var user = new User
                    {
                        Id = (int)reader["id"],
                        Email = reader["email"].ToString(),
                        Name = reader["name"].ToString(),
                        Password = reader["password"].ToString(),
                        IsAdmin = (bool)reader["isAdmin"]
                    };
                    userList.Add(user);
                }
                DbConnection.ConnectionInstance.CloseConnection();
            }
            else
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return null;
            }
            return userList;

        }

        public bool CreateUser(User user)
        {
            string query = string.Format("insert into dbo.Users (email, name, password, isAdmin) values (@email, @name, @password, @isAdmin); ");
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
                Value = ((user.IsAdmin) ? 1 : 0)
            };
            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }
            DbConnection.ConnectionInstance.CloseConnection();
            return false;
        }

        public bool UpdateUser(User user)
        {
            string query = string.Format("update dbo.Users set name = @name, password = @password, isAdmin = @isAdmin WHERE email = @email; ");
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
            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }
            DbConnection.ConnectionInstance.CloseConnection();
            return false;
        }

        public bool DeleteUser(User user)
        {
            string query = string.Format("delete from dbo.Users where email = @email ");
            var sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@email", SqlDbType.VarChar)
            {
                Value = Convert.ToString(user.Email)
            };
            if (DbConnection.ConnectionInstance.ExecuteParameterQuery(query, sqlParameters))
            {
                DbConnection.ConnectionInstance.CloseConnection();
                return true;
            }
            DbConnection.ConnectionInstance.CloseConnection();
            return false;
        }
    }
}
