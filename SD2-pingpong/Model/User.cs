using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<MatchPP> Matches { get; set; } 

        public User()
        {

        }

        public User(string name, string email, string password)
        {
            Name = name;
            Password = password;
            Email = email;
            IsAdmin = false;
        }

        public User(string name, string email, string password, bool isAdmin) : this(name, email, password)
        {
            IsAdmin = isAdmin;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id;
        }
    }
}
