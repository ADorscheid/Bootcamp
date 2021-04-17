using System.Collections.Generic;
using System.IO;
using System.Linq;
using HotelReservations.Models;

namespace HotelReservations.DAO
{
    public class UserFakeDao : IUserDao
    {
        private static List<User> _users = new List<User>();

        public UserFakeDao()
        {
            if (_users.Count == 0)
            {
                StreamReader dataInput = new StreamReader("./users.txt");
                while (!dataInput.EndOfStream)
                {
                    string dataLine = dataInput.ReadLine();
                    string[] lineUser = dataLine.Split(",");
                    try
                    {
                        if (lineUser.Length == 7 && int.TryParse(lineUser[0], out int parsedId))
                        {
                            User newUser = new User()
                            {
                                Id = parsedId,
                                FirstName = lineUser[1],
                                LastName = lineUser[2],
                                Username = lineUser[3],
                                PasswordHash = lineUser[4],
                                Salt = lineUser[5],
                                Role = lineUser[6]
                            };
                            _users.Add(newUser);
                        }
                    }
                    catch
                    {
                        //skip user, bad input
                    }
                } //while (!dataInput.EndOfStream)
            } //if (_users == null || _users.Count == 0)
        }

        public User GetUser(string username)
        {
            User user = _users.SingleOrDefault(x => x.Username == username);

            return user;
        }
    }
}
