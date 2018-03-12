namespace Akka.Net.Succinctly.Chapter8.Messages
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