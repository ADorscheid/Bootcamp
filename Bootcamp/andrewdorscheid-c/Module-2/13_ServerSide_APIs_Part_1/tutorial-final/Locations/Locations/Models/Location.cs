using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locations
{
    public class Location
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Location(int? id, string name, string address, string city, string state, string zip)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}
