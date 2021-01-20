using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Core.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Animal> Animals { get; set; }

    }

    public class Animal
    {
        public string AnimalId { get; set; }
        public string AnimalName { get; set; }
    }

    public class UserData
    {
        public List<User> Users { get; set; }
    }
}
