using Akka.Actor;
using System;
using System.Threading;

namespace Akka.Net.Succinctly.Routers
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<Add>(add => HandleAddition(add));
        }

        public void HandleAddition(Add add)
        {
            Console.WriteLine($"{Self.Path} received the request: {add.Term1}+{add.Term2}");
            if (!(Sender is DeadLetterActorRef))
                Sender.Tell(new Answer(add.Term1 + add.Term2));
        }
    }
}