namespace Akka.Net.Succinctly.Chapter5
{
    public class EmailMessage
    {
        public EmailMessage(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }
        public string From { get; }
        public string To { get; }
        public string Content { get; }
    }
}