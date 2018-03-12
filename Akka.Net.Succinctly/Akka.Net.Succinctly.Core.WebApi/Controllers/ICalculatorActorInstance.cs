using Akka.Net.Succinctly.Core.WebApi.Actors;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Core.WebApi.Controllers
{
    public interface ICalculatorActorInstance
    {
        Task<AnswerMessage> Sum(AddMessage message);
    }
}