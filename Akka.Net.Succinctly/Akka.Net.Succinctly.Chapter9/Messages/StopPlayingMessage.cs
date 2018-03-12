namespace Akka.Net.Succinctly.Chapter9.Messages
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