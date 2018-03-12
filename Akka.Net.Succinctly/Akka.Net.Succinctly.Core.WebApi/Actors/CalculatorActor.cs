using Akka.Actor;
using System;

namespace Akka.Net.Succinctly.Core.WebApi.Actors
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<AddMessage>(add =>
            {
                Sender.Tell(new AnswerMessage(add.Term1 + add.Term2));
            });
        }
    }
}