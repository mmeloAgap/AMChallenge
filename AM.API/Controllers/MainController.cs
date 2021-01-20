using AM.API.Handler;
using AM.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AM.API.Controllers
{
    [ApiController]
    [Route("[controller]/{action}")]
    public class MainController : ControllerBase
    {
        private ILogger<MainController> _logger;
        private IUserHandler _userHandler;

        public MainController(ILogger<MainController> logger, IUserHandler userHandler)
        {
            _logger = logger;
            _userHandler = userHandler ?? throw new ArgumentNullException(nameof(userHandler));
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public IActionResult Authorize(UserRequest user)
        {
            var response = _userHandler.Authenticate(user);
            if(response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }



    }
}
