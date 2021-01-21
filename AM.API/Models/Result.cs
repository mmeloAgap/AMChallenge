using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.API.Models
{
    public class Result
    {
        [JsonProperty("matchedWord")]
        public string MatchedWord { get; set; }
        [JsonProperty("distance")]
        public string Distance { get; set; }
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

    }
}
