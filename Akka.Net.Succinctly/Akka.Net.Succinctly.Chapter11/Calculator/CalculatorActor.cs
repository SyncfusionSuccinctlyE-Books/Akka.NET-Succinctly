using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Chapter11.Calculator
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<AddMessage>(message => HandleAddMessage(message));
        }

        public void HandleAddMessage(AddMessage message)
        {
            Sender.Tell(new AnswerMessage(message.Term1 + message.Term2));
        }
    }
}
