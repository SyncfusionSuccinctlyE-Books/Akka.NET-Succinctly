using Akka.Actor;
using System;
using Akka.Net.Succinctly.Chapter9.Actors;
using Akka.Net.Succinctly.Chapter9.Messages;

namespace Akka.Net.Succinctly.Chapter10
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            var dispatcher = system.ActorOf(Props.Create<MusicPlayerCoordinatorActor>());

            dispatcher.Tell(new PlaySongMessage("Bohemian Rapsody", "John"));
            dispatcher.Tell(new PlaySongMessage("Stairway to heaven", "Andrew"));

            Console.Read();

            system.Terminate();
        }
    }
}