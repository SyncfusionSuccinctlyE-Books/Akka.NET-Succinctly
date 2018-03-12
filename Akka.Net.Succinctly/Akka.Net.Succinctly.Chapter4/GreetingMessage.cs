namespace Akka.Net.Succinctly.Chapter4
{
    public class GreetingMessage
    {
        public GreetingMessage(string greeting)
        {
            Greeting = greeting;
        }

        public string Greeting { get; }
    }
}
