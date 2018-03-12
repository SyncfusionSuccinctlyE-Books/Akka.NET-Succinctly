using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Chapter6
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef musicPlayer = system.ActorOf<MusicPlayerActor>("musicPlayer");

            musicPlayer.Tell(new PlaySongMessage("Smoke on the water"));
            musicPlayer.Tell(new PlaySongMessage("Another brick on the wall"));
            musicPlayer.Tell(new StopPlayingMessage());
            musicPlayer.Tell(new StopPlayingMessage());
            musicPlayer.Tell(new PlaySongMessage("Another brick on the wall"));

            Console.Read();
            system.Terminate();
        }
    }
}
