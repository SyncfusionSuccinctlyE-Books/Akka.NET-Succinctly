using Akka.Actor;
using System;
using Akka.Net.Succinctly.Chapter8.Actors;
using Akka.Net.Succinctly.Chapter8.Messages;

namespace Akka.Net.Succinctly.Chapter8
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            var dispatcher = system.ActorOf<MusicPlayerCoordinatorActor>("player-coordinator");
            var stats = system.ActorOf<SongPerformanceActor>("statistics");

            dispatcher.Tell(new PlaySongMessage("Smoke on the water", "John"));
            dispatcher.Tell(new PlaySongMessage("Smoke on the water", "Mike"));
            dispatcher.Tell(new PlaySongMessage("Another Brick on the wall", "Andrew"));
            Console.Read();

            system.Terminate();
        }
    }
}