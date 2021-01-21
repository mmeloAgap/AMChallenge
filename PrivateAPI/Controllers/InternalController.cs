using AM.Core.Manager;
using AM.Core.Model.PrivateAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrivateAPI.Helpers;
using PrivateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class InternalController : ControllerBase
    {
        private ILogger<InternalController> _logger;
        private IBotManager _botManager;

        public InternalController(ILogger<InternalController> logger, IBotManager botManager)
        {
            _logger = logger;
            _botManager = botManager;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok("Hello World from private api");
        }



        [HttpPost]
        [Route("Predict")]
        public IActionResult Predict(BotRequest botRequest)
        {
            var result = _botManager.Predict(botRequest);
            if(result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }

    }
}
