using System;
using Akka.Actor;

namespace Akka.Net.Succinctly.Chapter4
{
    public class MyUntypedActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var greeting = message as GreetingMessage;
            if (greeting != null)
            {
                GreetingMessageHandler(greeting);
            }
        }

        private void GreetingMessageHandler(GreetingMessage greeting)
        {
            Console.WriteLine($"Untyped Actor named: {Self.Path.Name}");
            Console.WriteLine($"Received a greeting: {greeting.Greeting}");
            Console.WriteLine($"Actor's path: {Self.Path}");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name}");
        }
    }
}