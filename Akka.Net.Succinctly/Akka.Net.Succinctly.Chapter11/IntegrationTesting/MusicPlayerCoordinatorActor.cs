using Akka.Actor;
using System.Collections.Generic;
using System;

namespace Akka.Net.Succinctly.Chapter11.IntegrationTesting
{
    public class MusicPlayerCoordinatorActor : ReceiveActor
    {
        protected Dictionary<string, IActorRef> MusicPlayerActors;

        public MusicPlayerCoordinatorActor()
        {
            MusicPlayerActors = new Dictionary<string, IActorRef>();

            Receive<PlaySongMessage>(message => PlaySong(message));
        }

        private void PlaySong(PlaySongMessage message)
        {
            var musicPlayerActor = EnsureMusicPlayerActorExists(message.User);
            musicPlayerActor.Tell(message);
        }

        private IActorRef EnsureMusicPlayerActorExists(string user)
        {
            IActorRef musicPlayerActorRef;
            if (MusicPlayerActors.ContainsKey(user))
            {
                musicPlayerActorRef = MusicPlayerActors[user];
            }
            else
            {
                musicPlayerActorRef = Context.ActorOf<MusicPlayerActor>(user);
                MusicPlayerActors.Add(user, musicPlayerActorRef);
            }
            return musicPlayerActorRef;
        }
    }
}