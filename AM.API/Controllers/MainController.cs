using AM.API.Handler;
using AM.API.Manager;
using AM.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private ILogger<MainController> _logger;
        private IUserHandler _userHandler;
        private IQuestionManager _questionManager;

        public MainController(ILogger<MainController> logger, IUserHandler userHandler, IQuestionManager questionManager)
        {
            _logger = logger;
            _userHandler = userHandler ?? throw new ArgumentNullException(nameof(userHandler));           
            _questionManager = questionManager ?? throw new ArgumentNullException(nameof(questionManager));
        }


        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        [Route("Authorize")]
        public IActionResult Authorize(UserRequest user)
        {
            var response = _userHandler.Authenticate(user);
            if(response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }


        [Authorize]
        [HttpPost]
        [Route("singleCall")]
        public async Task<IActionResult> SingleCall(SingleCallRequest singleCallRequest)
        {
            singleCallRequest.RequestId = Guid.NewGuid();

            var result = await _questionManager.SingleCall(singleCallRequest);

            _logger.LogInformation(JsonConvert.SerializeObject(new LogResponse() { RequestId = singleCallRequest.RequestId, Result = result, UserWord = singleCallRequest.Word, TimeStamp = DateTime.UtcNow }));

            return Ok(result);
        }



        [Authorize]
        [HttpPost]
        [Route("talk")]
        public async Task<IActionResult> Handle(QuestionRequest questionRequest)
        {
            if(Equals(questionRequest.RequestId, Guid.Empty))
            {
                questionRequest.RequestId =  Guid.NewGuid();
            }


            var user = getUser();
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _questionManager.HandleQuestion(questionRequest, user.UserId);

            _logger.LogInformation(JsonConvert.SerializeObject(new LogResponse() { RequestId = questionRequest.RequestId, Result = result, UserWord = questionRequest.Word, TimeStamp = DateTime.UtcNow}));

            return Ok(result);
        }


        private User getUser()
        {
            var user = HttpContext.Items["User"];
            if (user == null)
            {
               return null;
            }
 
            return (User)user;
        }


    }
}
