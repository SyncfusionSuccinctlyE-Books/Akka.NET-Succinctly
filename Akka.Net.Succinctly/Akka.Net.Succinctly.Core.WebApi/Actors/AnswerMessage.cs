namespace Akka.Net.Succinctly.Core.WebApi.Actors
{
    public class AnswerMessage
    {
        public AnswerMessage(double value)
        {
            Value = value;
        }

        public double Value;
    }
}