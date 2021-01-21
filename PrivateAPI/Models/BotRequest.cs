using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateAPI.Models
{
    public class BotRequest
    {
        [JsonProperty("possibleWordMatches")]
        public List<string> PossibleWordMatches { get; set; }
        [JsonProperty("userResponse")]
        public string UserResponse { get; set; }

    }
}