using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tournament
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public IList<Match> Matches { get; set; }

        public Tournament()
        {
            Matches = new List<Match>();
        }

        public Tournament(string name)
        {
            Name = name;
            Status = "tba";
            Matches = new List<Match>();
        }

        public Tournament(string name, string status)
        {
            Name = name;
            Status = status;
            Matches = new List<Match>();
        }
    }
}
