using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.orm;
using Model;

namespace DataAccess.userdao
{
    public class OrmUserDAO : IUserDAO
    { 

        public User FindById(int id)
        {
            return OrmDatabase.Instance.Users.FirstOrDefault(user => user.Id == id);
        }

        public User FindByName(string name)
        {
            return OrmDatabase.Instance.Users.FirstOrDefault(user => user.Name == name);
        }

        public User FindByEmail(string email)
        {
            return OrmDatabase.Instance.Users.FirstOrDefault(user => user.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }

        public IList<User> FindAllUsers()
        {
            return OrmDatabase.Instance.Users.ToList(); 
        }

        public bool CreateUser(User user)
        {
            OrmDatabase.Instance.Users.Add(user);
            OrmDatabase.Instance.SaveChanges();
            return true;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(User user)
        {
            OrmDatabase.Instance.Users.Remove(user);
            OrmDatabase.Instance.SaveChanges();
            return true;
        }
    }
}
