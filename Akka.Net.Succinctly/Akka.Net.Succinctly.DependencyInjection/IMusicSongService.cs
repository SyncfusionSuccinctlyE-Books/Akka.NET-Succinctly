namespace Akka.Net.Succinctly.DependencyInjection
{
    public interface IMusicSongService
    {
        Song GetSongByName(string songName);
    }
}