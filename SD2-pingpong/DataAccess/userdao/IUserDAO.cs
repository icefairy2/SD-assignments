using System.Collections.Generic;
using Model;

namespace DataAccess.userdao
{
    public interface IUserDAO
    {
        User FindById(int id);
        User FindByName(string name);
        User FindByEmail(string email);
        IList<User> FindAllUsers();
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
