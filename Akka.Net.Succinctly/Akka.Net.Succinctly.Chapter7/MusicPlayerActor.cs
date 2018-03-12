using System;
using Akka.Actor;

namespace Akka.Net.Succinctly.Chapter7
{
    public class MusicPlayerActor : ReceiveActor
    {
        protected PlaySongMessage CurrentSong;

        public MusicPlayerActor()
        {
            StoppedBehavior();
        }

        private void StoppedBehavior()
        {
            Receive<PlaySongMessage>(m => PlaySong(m));
            Receive<StopPlayingMessage>(m => Console.WriteLine($"{m.User}'s player: Cannot stop, the actor is already stopped"));
        }

        private void PlayingBehavior()
        {
            Receive<PlaySongMessage>(m => Console.WriteLine($"{CurrentSong.User}'s player: Cannot play. Currently playing '{CurrentSong.Song}'"));
            Receive<StopPlayingMessage>(m => StopPlaying());
        }

        private void PlaySong(PlaySongMessage message)
        {
            CurrentSong = message;
            Console.WriteLine($"{CurrentSong.User} is currently listening to '{CurrentSong.Song}'");

            Become(PlayingBehavior);
        }

        private void StopPlaying()
        {
            Console.WriteLine($"{CurrentSong.User}'s player is currently stopped.");
            CurrentSong = null;
            Become(StoppedBehavior);
        }
    }
}