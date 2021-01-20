using AM.Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AM.API.Handler
{
    public interface IUserHandler
    {
        AuthenticateResponse Authenticate(UserRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserHandler : IUserHandler
    {
        private IEnumerable<User> _users;

        public UserHandler(IOptions<UserData> userData)
        {    
            _users = userData.Value.Users;
        }

        public AuthenticateResponse Authenticate(UserRequest model)
        {
   
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse() {Token = token};
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.UserId == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this phrase is big enough to be a secret");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) , new Claim("username", user.Username.ToString())}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
