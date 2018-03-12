using System;
using Akka.Actor;

namespace Akka.Net.Succinctly.Chapter4
{
    public class GreetingDispatcherActor : ReceiveActor
    {
        public GreetingDispatcherActor()
        {
            base.Receive<GreetingMessage>(message => GreetingMessageHandler(message));
        }

        private void GreetingMessageHandler(GreetingMessage greeting)
        {
            IActorRef typedActor = Context.ActorOf<MyTypedActor>("typed-actor-name");

            typedActor.Tell(greeting);
        }
    }
}