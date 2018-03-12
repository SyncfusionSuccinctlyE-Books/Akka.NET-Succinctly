using System;
using Akka.Actor;
using Akka.Net.Succinctly.Chapter9.Messages;

namespace Akka.Net.Succinctly.Chapter9.Actors
{
    public class MusicPlayerActor : ReceiveActor
    {
        protected PlaySongMessage CurrentSong;

        public MusicPlayerActor()
        {
            Receive<PlaySongMessage>(e => PlaySong(e));
        }

        private void PlaySong(PlaySongMessage message)
        {
            CurrentSong = message;

            if (message.Song == "Bohemian Rapsody")
            {
                throw new SongNotAvailableException("Bohemian Rapsody is not available");
            }

            if (message.Song == "Stairway to heaven")
            {
                throw new MusicSystemCorruptedException("cannot retrieve the song from the database");
            }

            Console.WriteLine($"{CurrentSong.User} is currently listening to '{CurrentSong.Song}'");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine($"{Self.Path.Name}: PreRestart {reason.Message}");
        }

        protected override void PreStart()
        {
            Console.WriteLine($"{Self.Path.Name}: PreStart");
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine($"{Self.Path.Name}: PostRestart {reason.Message}");
        }

        protected override void PostStop()
        {
            Console.WriteLine($"{Self.Path.Name}: PostStop");
        }
    }
}