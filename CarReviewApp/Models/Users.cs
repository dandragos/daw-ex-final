using System;
namespace CarReviewApp.Models
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<Users> GetUsers()
        {
            return new List<Users>() { new Users { Username = "peter", Password = "123", Role="Admin" },
                                   new Users { Username = "parker", Password = "456", Role="Guest" }
    };
        }
    }

}

