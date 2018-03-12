using Akka.Actor;
using System;

namespace Akka.Net.Succinctly.Chapter4
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<Add>(add => Sender.Tell(new Answer(add.Term1 + add.Term2)));
        }
    }
}