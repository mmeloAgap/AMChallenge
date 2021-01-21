using AM.Core.Model.PrivateAPI;
using Microsoft.Extensions.Logging;
using PrivateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Manager
{
    public class BotManager : IBotManager
    {
        private ILogger<BotManager> _logger;

        public BotManager(ILogger<BotManager> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

     
        public BotResult Predict(BotRequest botRequest)
        {
            var results = CalculateDistance(botRequest.UserResponse, botRequest.PossibleWordMatches);
            
            var result = results.OrderByDescending(x => x.Distance).FirstOrDefault();

            return new BotResult() { Distance = result.Distance, MatchedWord = result.Word };

        }
    
      
        private List<Result> CalculateDistance(string word, List<string> possibleWordMatches)
        {
            List<Result> results = new List<Result>();

            foreach (string wrd in possibleWordMatches)
            {
                Result result = new Result();

                if (word.Equals(wrd))
                {
                    result.Word = wrd;
                    result.Distance = (double)word.Length / wrd.Length;
                   
                }              
                else
                {
                    int commonChar = MatchCharacters(word, wrd);

                    var biggerWord = word;

                    if (word.Length < wrd.Length)
                        biggerWord = wrd;

                    result.Word = wrd;
                    
                    if(commonChar == 0)
                    {
                        result.Distance = 0.0;
                    }else
                    {
                        result.Distance = (double) commonChar / biggerWord.Length;
                    }
                }

                results.Add(result);
            }

            return results;
        }


        private int MatchCharacters(string word, string wrd)
        {

            int common = 0;
            string toIterate = string.Empty;
            if (word.Length > wrd.Length) { 
                toIterate = word;
                word = wrd;
            }else
            {
                toIterate = wrd;
            }
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < toIterate.Length; j++)
                {
                    if (word[i] == toIterate[j])
                    {
                        toIterate = toIterate.Remove(j, 1);
                        common++;
                        break;
                    }
                }
            }

            return common;
        }

        private class Result
        {
            public double Distance { get; set; }
            public string Word { get; set; }
        }
    
    
    }
}
