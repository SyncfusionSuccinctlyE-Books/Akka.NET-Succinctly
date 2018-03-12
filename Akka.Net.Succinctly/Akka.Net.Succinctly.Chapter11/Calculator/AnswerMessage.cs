namespace Akka.Net.Succinctly.Chapter11.Calculator
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
