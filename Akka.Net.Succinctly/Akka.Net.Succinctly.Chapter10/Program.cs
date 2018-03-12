using System;
using Akka.Actor;
using Akka.Event;
using Akka.Net.Succinctly.Chapter10.Actors;
using Akka.Net.Succinctly.Chapter10.Actors.Messages;

namespace Akka.Net.Succinctly.Chapter10
{
    partial class Program
    {
        static void Main(string[] args)
        {
            PublishSubscribeExample();


            //DeadLetterExample();
        }

        private static void PublishSubscribeExample()
        {

            ActorSystem system = ActorSystem.Create("pub-sub-example");

            var publisher = system.ActorOf<BookPublisher>("book-publisher");

            var subscriber1 = system.ActorOf<BookSubscriber>("book-subscriber1");
            var subscriber2 = system.ActorOf<BookSubscriber>("book-subscriber2");

            system.EventStream.Subscribe(subscriber1, typeof(NewBookMessage));
            system.EventStream.Subscribe(subscriber2, typeof(NewBookMessage));
              
            publisher.Tell(new NewBookMessage("Don Quixote"));
            publisher.Tell(new NewBookMessage("War and Peace"));

            Console.Read();

            system.Terminate();
        }

        static void DeadLetterExample()
        {
            ActorSystem system = ActorSystem.Create("dead-letter-example");

            var deadLettersSubscriber = system.ActorOf<DeadLetterMonitor>("dl-subscriber");
            var echoActor = system.ActorOf<EchoActor>("empty-echo-actor");

            system.EventStream.Subscribe(deadLettersSubscriber, typeof(DeadLetter));

            echoActor.Tell(PoisonPill.Instance);
            echoActor.Tell("Hello");
            Console.Read();

            system.Terminate();
        }
    }
}