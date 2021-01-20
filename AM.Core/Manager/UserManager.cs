using AM.Core.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Manager
{
    public class UserManager : IUserManager
    {
        private ILogger<UserManager> _logger;


        public UserManager(ILogger<UserManager> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<string> Authenticate()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRequest>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
