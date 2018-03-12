using Akka.Actor;
using System;

namespace Akka.Net.Succinctly.Chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef dispatcher = system.ActorOf<MusicPlayerCoordinatorActor>("player-coordinator");

            dispatcher.Tell(new PlaySongMessage("Smoke on the water", "John"));
            dispatcher.Tell(new PlaySongMessage("Another brick on the wall", "Mike"));

            dispatcher.Tell(new StopPlayingMessage("John"));
            dispatcher.Tell(new StopPlayingMessage("Mike"));

            dispatcher.Tell(new StopPlayingMessage("Mike"));

            Console.Read();

            system.Terminate();
        }
    }
}