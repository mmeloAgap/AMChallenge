using AM.API.Models;
using System.Threading.Tasks;

namespace AM.API.Manager
{
    public interface IQuestionManager
    {
        public Task<string> HandleQuestion(QuestionRequest questionRequest, int userId);

        public Task<string> SingleCall(SingleCallRequest questionRequest);
    }
}
