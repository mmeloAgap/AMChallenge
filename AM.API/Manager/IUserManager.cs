using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AM.API.Manager
{
    public interface IUserManager
    {
        List<string> GetUserAnimals(int userId);      
    }
}
