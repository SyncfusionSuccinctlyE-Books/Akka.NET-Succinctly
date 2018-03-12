namespace Akka.Net.Succinctly.Chapter6
{
    public class PlaySongMessage
    {
        public PlaySongMessage(string song)
        {
            Song = song;
        }

        public string Song { get; }
    }
}