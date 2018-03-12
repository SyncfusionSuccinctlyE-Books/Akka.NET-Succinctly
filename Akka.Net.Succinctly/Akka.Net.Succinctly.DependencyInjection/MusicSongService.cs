namespace Akka.Net.Succinctly.DependencyInjection
{
    public class MusicSongService : IMusicSongService
    {
        public Song GetSongByName(string songName)
        {
            return new Song(songName, new byte[0]);
        }
    }
}