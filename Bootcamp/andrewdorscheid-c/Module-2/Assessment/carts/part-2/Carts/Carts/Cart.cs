using System;

namespace Carts
{
    public class Cart
    {
        public Cart()
        { }

        public Cart(string username, string cookieValue, DateTime created)
        {
            CookieValue = cookieValue;
            Created = created;
            Username = username;
        }

        public string CookieValue { get; set; }
        public DateTime Created { get; set; }
        public long Id { get; set; }
        public string Username { get; set; }
    }
}
