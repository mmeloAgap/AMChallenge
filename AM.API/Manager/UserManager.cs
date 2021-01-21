using AM.API.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.API.Manager
{
    public class UserManager : IUserManager
    {
        private ILogger<UserManager> _logger;
        private readonly Settings _settings;


        public UserManager(ILogger<UserManager> logger, IOptions<Settings> settings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));

        }

        public List<string> GetUserAnimals(int userId)
        {
            var users = _settings.Users;
            var animals =  users.Where(x => x.UserId == userId).FirstOrDefault().Animals;
            if(animals == null)
            {
                throw new Exception("User has no animal in his name");
            }

            var animalNames = new List<string>();

            foreach (Animal animal in animals)
            {
                animalNames.Add(animal.AnimalName);
            }

            return animalNames;
        }
    }
}
