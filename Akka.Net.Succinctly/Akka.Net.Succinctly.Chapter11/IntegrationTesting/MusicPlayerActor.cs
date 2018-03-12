using System;
using Akka.Actor;

namespace Akka.Net.Succinctly.Chapter11.IntegrationTesting
{
public class MusicPlayerActor : ReceiveActor
{
    protected PlaySongMessage CurrentSong;

    public MusicPlayerActor()
    {
        Receive<PlaySongMessage>(m => PlaySong(m));
    }

        private void PlaySong(PlaySongMessage message)
        {
            CurrentSong = message;
            Console.WriteLine($"{CurrentSong.User} is currently listening to '{CurrentSong.Song}'");
            Sender.Tell("Item received");
        }
}
}