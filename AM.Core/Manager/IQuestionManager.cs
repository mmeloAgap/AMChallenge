using AM.Core.Model.PublicAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Manager
{
    public interface IQuestionManager
    {
        public Task HandleQuestion(QuestionRequest questionRequest, int userId);
    }
}
