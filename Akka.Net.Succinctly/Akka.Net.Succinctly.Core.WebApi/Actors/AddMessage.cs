namespace Akka.Net.Succinctly.Core.WebApi.Actors
{
    public class AddMessage
    {
        public AddMessage(double term1, double term2)
        {
            Term1 = term1;
            Term2 = term2;
        }

        public double Term1;
        public double Term2;
    }
}