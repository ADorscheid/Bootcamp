using System;

namespace Posts
{
    public class User
    {
        public User()
        { }

        public User(String firstName, String lastName, String email, String role, DateTime created)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
            Created = created;
        }

        public DateTime Created { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public long Id { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
