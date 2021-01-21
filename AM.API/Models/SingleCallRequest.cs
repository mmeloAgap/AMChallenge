using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.API.Models
{
    public class SingleCallRequest
    {
        [JsonRequired]
        [JsonProperty("word")]
        public string Word { get; set; }
        [JsonRequired]
        [JsonProperty("possibleMatches")]
        public List<string> PossibleMatches { get; set; }
        [JsonProperty("requestId")]
        public Guid RequestId { get; set; }

    }
}
