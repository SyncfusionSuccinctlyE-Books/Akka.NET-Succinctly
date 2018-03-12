using Akka.Actor;

namespace Akka.Net.Succinctly.DependencyInjection
{
    public class MusicActor : ReceiveActor
    {
        private IMusicSongService SongService { get; }

        public MusicActor(IMusicSongService songService)
        {
            SongService = songService;
            Receive<string>(s => HandleSongRetrieval(s));
        }

        public void HandleSongRetrieval(string songName)
        {
            var song = SongService.GetSongByName(songName);
            /* do something with this song*/

        }
    }
}