using System;
using System.Collections.Generic;
using System.Text;

namespace AM.API.Models
{
    public class BotResult
    {
        public string MatchedWord { get; set; }
        public double Distance { get; set; }
    }
}
