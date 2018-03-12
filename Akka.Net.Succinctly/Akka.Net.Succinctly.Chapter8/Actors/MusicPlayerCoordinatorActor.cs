using Akka.Actor;
using System.Collections.Generic;
using System;
using Akka.Net.Succinctly.Chapter8.Messages;

namespace Akka.Net.Succinctly.Chapter8.Actors
{
    public class MusicPlayerCoordinatorActor : ReceiveActor
    {
        protected Dictionary<string, IActorRef> MusicPlayerActors;

        public MusicPlayerCoordinatorActor()
        {
            MusicPlayerActors = new Dictionary<string, IActorRef>();

            Receive<PlaySongMessage>(message => PlaySong(message));
            Receive<StopPlayingMessage>(message => StopPlaying(message));
        }

        private void StopPlaying(StopPlayingMessage message)
        {
            var musicPlayerActor = GetMusicPlayerActor(message.User);
            if (musicPlayerActor != null)
            {
                musicPlayerActor.Tell(message);
            }
        }

        private void PlaySong(PlaySongMessage message)
        {
            var musicPlayerActor = EnsureMusicPlayerActorExists(message.User);
            musicPlayerActor.Tell(message);
        }

        private IActorRef EnsureMusicPlayerActorExists(string user)
        {
            IActorRef musicPlayerActorReference = GetMusicPlayerActor(user);

            MusicPlayerActors.TryGetValue(user, out musicPlayerActorReference);

            if (musicPlayerActorReference == null)
            {
                //create a new actor's instance
                musicPlayerActorReference = Context.ActorOf<MusicPlayerActor>(user);
                //add the newly created actor in the dictionary
                MusicPlayerActors.Add(user, musicPlayerActorReference);
            }
            return musicPlayerActorReference;
        }

        private IActorRef GetMusicPlayerActor(string user)
        {
            IActorRef musicPlayerActorReference;
            MusicPlayerActors.TryGetValue(user, out musicPlayerActorReference);
            return musicPlayerActorReference;
        }
    }
}