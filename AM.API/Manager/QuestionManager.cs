using AM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AM.API.Manager
{
    public class QuestionManager : IQuestionManager
    {

        private IUserManager _userManager;
        private Settings _settings;
        private ILogger<QuestionManager> _logger;

        public QuestionManager(IUserManager userManager, IOptions<Settings> settings, ILogger<QuestionManager> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<string> HandleQuestion(QuestionRequest questionRequest, int userId)
        {

            BotRequest botRequest = new BotRequest();

            switch (questionRequest.QuestionId)
            {
                case 1:
                    var animalNames =  AnimalSelector(userId);
                    botRequest.PossibleWordMatches = animalNames;
                    botRequest.UserResponse = questionRequest.Word;                   
                    _logger.LogInformation(JsonConvert.SerializeObject(new Log() { RequestId = questionRequest.RequestId, PossibleWordMatch = animalNames, UserWord = questionRequest.Word, TimeStamp = DateTime.UtcNow, UserId = userId }));
                    return await CallBot(botRequest);

                case 2:
                    var doctorNames = DoctorSelector();
                    botRequest.PossibleWordMatches = doctorNames;
                    botRequest.UserResponse = questionRequest.Word;
                    _logger.LogInformation(JsonConvert.SerializeObject(new Log() { RequestId = questionRequest.RequestId, PossibleWordMatch = doctorNames, UserWord = questionRequest.Word, TimeStamp = DateTime.UtcNow, UserId = userId }));
                    return await CallBot(botRequest);

                default:
                    throw new Exception("SORRY, I didn´t understand");
            }

        }

        public async Task<string> SingleCall(SingleCallRequest singlecallRequest)
        {
            BotRequest botRequest = new BotRequest();
            botRequest.PossibleWordMatches = singlecallRequest.PossibleMatches;
            botRequest.UserResponse = singlecallRequest.Word;
            _logger.LogInformation(JsonConvert.SerializeObject(new Log() { RequestId = singlecallRequest.RequestId, PossibleWordMatch = singlecallRequest.PossibleMatches, UserWord = singlecallRequest.Word, TimeStamp = DateTime.UtcNow}));
            return await CallBot(botRequest);
        }

        private List<string> AnimalSelector(int userId)
        { 
            return  _userManager.GetUserAnimals(userId);

        }

        private List<string> DoctorSelector()
        {
            return _settings.Doctors;

        }

        private async Task<string> CallBot(BotRequest botRequest)
        {
            var url = _settings.PrivateApiUrl;
            var apiKey = _settings.ApiKey;

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST).AddHeader("ApiKey", apiKey).AddJsonBody(botRequest);

            var response = await client.ExecuteAsync(request);

            return response.Content;


        }

       



    }
}
