using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.API.Models
{
    public class Log
    {
        [JsonProperty("requestId")]
        public Guid RequestId { get; set; }
        [JsonProperty("userWord")]
        public string UserWord { get; set; }
        [JsonProperty("possibleWordMatch")]
        public List<string> PossibleWordMatch { get; set; }
        [JsonProperty("wordMatched")]
        public string WordMatched { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("dateTime")]
        public DateTime TimeStamp { get; set; }
   
    }


    public class LogResponse : Log
    {
        [JsonProperty("result")]
        public string Result { get; set; }
    }


}
