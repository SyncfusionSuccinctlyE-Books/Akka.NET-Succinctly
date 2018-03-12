using System;
using Akka.Actor;
using Akka.Net.Succinctly.Chapter8.Messages;

namespace Akka.Net.Succinctly.Chapter8.Actors
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

            var statsActor = Context.ActorSelection("../../statistics");
            
            statsActor.Tell(message);
            //DisplayInformation();

            Become(PlayingBehavior);
        }

        private void DisplayInformation()
        {
            Console.WriteLine("Actor's information:");
            Console.WriteLine($"Typed Actor named: {Self.Path.Name}");
            Console.WriteLine($"Actor's path: {Self.Path}");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name}");
            Console.WriteLine($"Actor's parent: {Context.Self.Path.Parent.Name}");
        }

        private void StopPlaying()
        {
            Console.WriteLine($"{CurrentSong.User}'s player is currently stopped.");
            CurrentSong = null;
            Become(StoppedBehavior);
        }
    }
}