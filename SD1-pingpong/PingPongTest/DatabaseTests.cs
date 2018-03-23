using System;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PingPongTest
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void DatabaseConnectionTest()
        {
            var dbConnection = new DbConnection();
            var sqlConnection = dbConnection.OpenConnection();
            Assert.AreEqual(sqlConnection.State, System.Data.ConnectionState.Open);
            Assert.AreEqual(sqlConnection.ConnectionString, "Data Source=DESKTOP-R95RP8R;Initial Catalog=pingpong;Integrated Security=True");
            Assert.AreEqual(sqlConnection.Database, "pingpong");
        }

        [TestMethod]
        public void SelectTest()
        {
            var dbConnection = new DbConnection();
            var sqlConnection = dbConnection.OpenConnection();
            string query = string.Format("select * from dbo.Users;");
            Assert.IsNotNull(dbConnection.ExecuteSelectAllQuery(query));
        }

        [TestMethod]
        public void InsertTest()
        {
            var dbConnection = new DbConnection();
            var sqlConnection = dbConnection.OpenConnection();
            string query = string.Format("insert into dbo.Users (email, name, password, isAdmin) values (@email, @name, @password, @isAdmin);");
            var sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@email", SqlDbType.VarChar)
            {
                Value = "email"
            };
            sqlParameters[1] = new SqlParameter("@name", SqlDbType.VarChar)
            {
                Value = "test"
            };
            sqlParameters[2] = new SqlParameter("@password", SqlDbType.VarChar)
            {
                Value = "password"
            };
            sqlParameters[3] = new SqlParameter("@isAdmin", SqlDbType.Bit)
            {
                Value = 0
            };
            Assert.IsTrue(dbConnection.ExecuteInsertQuery(query, sqlParameters));
        }
    }
}
