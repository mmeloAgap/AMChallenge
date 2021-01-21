using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.API.Models
{
    public class Settings
    {
        public string TokenSecret { get; set; }
        public List<User> Users { get; set; }
        public string ApiKey { get; set; }
        public string PrivateApiUrl { get; set; }       
        public List<string> Doctors { get; set; }

    }
}
