using AM.Core.Model.PrivateAPI;
using PrivateAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Manager
{
    public interface IBotManager
    {
        BotResult Predict(BotRequest botRequest);
    }
}
