namespace Akka.Net.Succinctly.DependencyInjection
{
    public class Song
    {
        public Song(string songName, byte[] rowFormat)
        {
            SongName = songName;
            RowFormat = rowFormat;
        }

        public string SongName { get; }
        public byte[] RowFormat { get; }
    }
}