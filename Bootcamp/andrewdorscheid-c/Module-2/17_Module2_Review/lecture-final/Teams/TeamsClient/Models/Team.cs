using System;
using System.Collections.Generic;
using System.Text;

namespace TeamsClient.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Location { get; set; }
        public string TeamName { get; set; }
        public int Conference { get; set; }
        public int Division { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
