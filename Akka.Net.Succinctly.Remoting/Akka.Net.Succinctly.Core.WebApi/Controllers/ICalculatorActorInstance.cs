using Akka.Net.Succinctly.Core.Common;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Core.WebApi.Controllers
{
    public interface ICalculatorActorInstance
    {
        Task<AnswerMessage> Sum(AddMessage message);
    }
}