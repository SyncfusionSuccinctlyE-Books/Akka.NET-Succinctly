namespace Akka.Net.Succinctly.Chapter10.Actors.Messages
{
    public class NewBookMessage
    {
        public NewBookMessage(string name)
        {
            BookName = name;
        }

        public string BookName { get; }
    }
}