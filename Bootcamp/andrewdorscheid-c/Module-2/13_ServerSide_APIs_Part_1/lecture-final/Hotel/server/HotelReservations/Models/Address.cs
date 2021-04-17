using Newtonsoft.Json;

namespace HotelReservations.Models
{
  public class Address
  {
    public string Id { get; set; }
    [JsonProperty("address")]
    public string StreetAddress { get; set; }
    [JsonProperty("address2")]
    public string StreetAddress2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public Address(string address, string address2, string city, string state, string zip)
    {
        Id = System.Guid.NewGuid().ToString();
        StreetAddress = address;
        StreetAddress2 = address2;
        City = city;
        State = state;
        Zip = zip;
    }
  }
}
