using System;
using Akka.Actor;

namespace Akka.Net.Succinctly.Chapter4
{
    public class MyTypedActor : ReceiveActor
    {
        public MyTypedActor()
        {
            base.Receive<GreetingMessage>(message => GreetingMessageHandler(message));
        }

        private void GreetingMessageHandler(GreetingMessage greeting)
        {
            Console.WriteLine($"Typed Actor named: {Self.Path.Name}");
            Console.WriteLine($"Received a greeting: {greeting.Greeting}");
            Console.WriteLine($"Actor's path: {Self.Path}");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name}");
        }
    }
}