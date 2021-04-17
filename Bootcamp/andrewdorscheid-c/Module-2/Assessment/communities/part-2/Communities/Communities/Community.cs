using System;

namespace Communities
{
    public class Community
    {
        public Community()
        { }

        public Community(string name, DateTime created, decimal latitude, decimal longitude, bool isLive)
        {
            Created = created;
            IsLive = isLive;
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
        }

        public DateTime Created { get; set; }
        public long Id { get; set; }
        public bool IsLive { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
    }
}
