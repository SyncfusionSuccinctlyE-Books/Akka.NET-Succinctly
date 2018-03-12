using Akka.Actor;
using Akka.Net.Succinctly.Core.Common;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Core.WebApi.Controllers
{
    public class CalculatorActorInstance : ICalculatorActorInstance
    {
        private IActorRef _actor;

        public CalculatorActorInstance(ActorSystem actorSystem)
        {
            _actor = actorSystem.ActorOf(Props.Create<CalculatorActor>(), "calculator");
        }

        public async Task<AnswerMessage> Sum(AddMessage message)
        {
            return await _actor.Ask<AnswerMessage>(message);
        }
    }
}