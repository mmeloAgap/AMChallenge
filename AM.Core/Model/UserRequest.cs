using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Core.Model
{
    public class UserRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
