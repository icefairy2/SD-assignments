using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dao;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PingPongTest
{
    [TestClass]
    public class DAOTests
    {
        [TestMethod]
        public void SelectUserTest()
        {
            var userDao = new UserDAO();
            var testUser = new User("test", "emailSelectDao", "password", false);
            Assert.IsTrue(userDao.CreateUser(testUser));
            var returnedUser = userDao.FindByEmail(testUser.Email);
            
            Assert.IsTrue(testUser.Name == returnedUser.Name);
            Assert.IsTrue(testUser.Email == returnedUser.Email);
            Assert.IsTrue(testUser.Password == returnedUser.Password);
            Assert.IsTrue(testUser.IsAdmin == returnedUser.IsAdmin);
            userDao.DeleteUser(testUser);
        }

        [TestMethod]
        public void SelectAllUsersTest()
        {
            var userDao = new UserDAO();
            var testUserList = new List<User>();
            testUserList = userDao.FindAllUsers();

            Assert.IsTrue(testUserList.Any());
        }
    }
}
