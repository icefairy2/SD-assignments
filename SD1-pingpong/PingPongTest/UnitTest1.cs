using System;
using Dao;
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
            var sqlConnection = dbConnection.openConnection();
            Assert.AreEqual(sqlConnection.State, System.Data.ConnectionState.Open);
            Assert.AreEqual(sqlConnection.ConnectionString, "Data Source=DESKTOP-R95RP8R;Initial Catalog=pingpong;Integrated Security=True");
            Assert.AreEqual(sqlConnection.Database, "pingpong");
        }
    }
}
