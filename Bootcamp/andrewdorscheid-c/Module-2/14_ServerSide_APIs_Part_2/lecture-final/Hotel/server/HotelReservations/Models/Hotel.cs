namespace HotelReservations.Models
{
    /// <summary>
    /// A hotel property owned by the company.
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// The identifier for the hotel
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Hotel name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Location of the hotel
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// The star-rating for this hotel based on user reviews.
        /// </summary>
        public int Stars { get; set; }
        /// <summary>
        /// The total number of rooms at this hotel.
        /// </summary>
        public int RoomsAvailable { get; set; }
        /// <summary>
        /// The price per room per night, before fees and charges.
        /// </summary>
        public decimal CostPerNight { get; set; }
        /// <summary>
        /// URL for an image of this hotel
        /// </summary>
        public string CoverImage { get; set; }

        public Hotel(int id, string name, Address address, int stars, int rooms, decimal cost, string image)
        {
            Id = id;
            Name = name;
            Address = address;
            Stars = stars;
            RoomsAvailable = rooms;
            CostPerNight = cost;
            CoverImage = image;
        }

    }
}
