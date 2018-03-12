namespace Akka.Net.Succinctly.Chapter11.UnitTesting
{
public class CounterIncreasedMessage
{
    public string Song;
    public long Count;

    public CounterIncreasedMessage(string song, long count)
    {
        this.Song = song;
        this.Count = count;
    }
}
}