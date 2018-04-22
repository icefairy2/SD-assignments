using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public IList<MatchPP> Matches { get; set; }

        public Tournament()
        {
            Matches = new List<MatchPP>();
            Status = "tba";
        }

        public Tournament(string name)
        {
            Name = name;
            Status = "tba";
            Matches = new List<MatchPP>();
        }

        public Tournament(string name, string status)
        {
            Name = name;
            Status = status;
            Matches = new List<MatchPP>();
        }
    }
}
