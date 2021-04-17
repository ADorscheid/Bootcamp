using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Location { get; set; }
        public string TeamName { get; set; }
        public Conference Conference { get; set; }
        public Division Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

    }


}
