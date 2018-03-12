namespace Akka.Net.Succinctly.Chapter7
{
    public class StopPlayingMessage
    {
        public StopPlayingMessage(string user)
        {
            User = user;
        }

        public string User { get; }
    }
}