using AM.Core.Model;
using AM.Core.Model.PublicAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Manager
{
    public class QuestionManager : IQuestionManager
    {

        private IUserManager _userManager;
        private Settings _settings;

        public QuestionManager(IUserManager userManager, IOptions<Settings> settings)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task HandleQuestion(QuestionRequest questionRequest, int userId)
        {
            switch (questionRequest.QuestionId)
            {
                case 1:

                    var animalNames =  Animalselector(userId);
                    var url = _settings.PrivateApiUrl;
                    var apiKey = _settings.ApiKey;

                    BotRequest botRequest = new BotRequest { PossibleWordMatches = animalNames, UserResponse = questionRequest.Word};

                    var client = new RestClient(url);
                    var request = new RestRequest(Method.POST).AddHeader("ApiKey", apiKey).AddJsonBody(botRequest);
                    var response = await client.ExecuteAsync(request);
                    break;

            }
            throw new NotImplementedException();
        }



        private List<string> Animalselector(int userId)
        { 
            return  _userManager.GetUserAnimals(userId);

        }



        private 



    }
}
