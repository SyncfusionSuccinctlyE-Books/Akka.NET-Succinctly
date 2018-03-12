using Akka.Actor;
using System;
using Akka.Routing;

namespace Akka.Net.Succinctly.Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            //RoundRobin();
            //RandomRouter();
            //SmallestMailboxPool();
            ConsistentHashing();
            Console.Read();

        }

        public static void ConsistentHashing()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            var calculatorProps = Props.Create<CalculatorActor>()
                                    .WithRouter(new Akka.Routing.ConsistentHashingPool(4)
                                    .WithHashMapping(x =>
                                    {
                                        if (x is Add)
                                        {
                                            return ((Add)x).Term1;
                                        }

                                        return x;
                                    }));

            var calculatorRef = system.ActorOf(calculatorProps, "calculator");

            calculatorRef.Tell(new Add(100, 20));
            calculatorRef.Tell(new Add(100, 30));
            calculatorRef.Tell(new Add(12, 40));
            calculatorRef.Tell(new Add(100, 10));
            calculatorRef.Tell(new Add(14, 25));

            Console.Read();

            system.Terminate();
        }

        public static void SmallestMailboxPool()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            var calculatorProps = Props.Create<CalculatorActor>()
                                    .WithRouter(new Akka.Routing.SmallestMailboxPool(4));

            var calculatorRef = system.ActorOf(calculatorProps, "calculator");

            for (int i = 0; i < 1000; i++)
            {
                calculatorRef.Ask(new Add(10, 20));
                calculatorRef.Ask(new Add(11, 30));
                calculatorRef.Ask(new Add(12, 40));
                calculatorRef.Ask(new Add(13, 10));
                calculatorRef.Ask(new Add(14, 25));
            }

            Console.Read();

            system.Terminate();
        }

        public static void RandomRouter()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            var calculatorProps = Props.Create<CalculatorActor>()
                                    .WithRouter(new Akka.Routing.RandomPool(4));

            var calculatorRef = system.ActorOf(calculatorProps, "calculator");

            var result1 = calculatorRef.Ask(new Add(10, 20)).Result as Answer;
            var result2 = calculatorRef.Ask(new Add(11, 30)).Result as Answer;
            var result3 = calculatorRef.Ask(new Add(12, 40)).Result as Answer;
            var result4 = calculatorRef.Ask(new Add(13, 10)).Result as Answer;
            var result5 = calculatorRef.Ask(new Add(14, 25)).Result as Answer;

            Console.WriteLine($"Result 1 : {result1.Value}");
            Console.WriteLine($"Result 2 : {result2.Value}");
            Console.WriteLine($"Result 3 : {result3.Value}");
            Console.WriteLine($"Result 4 : {result4.Value}");
            Console.WriteLine($"Result 5 : {result5.Value}");

            Console.Read();

            system.Terminate();
        }

        public static void RoundRobin()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            var calculatorProps = Props.Create<CalculatorActor>()
                                    .WithRouter(new Akka.Routing.RoundRobinPool(4));

            var calculatorRef = system.ActorOf(calculatorProps, "calculator");

            var result1 = calculatorRef.Ask(new Add(10, 20)).Result as Answer;
            var result2 = calculatorRef.Ask(new Add(11, 30)).Result as Answer;
            var result3 = calculatorRef.Ask(new Add(12, 40)).Result as Answer;
            var result4 = calculatorRef.Ask(new Add(13, 10)).Result as Answer;
            var result5 = calculatorRef.Ask(new Add(14, 25)).Result as Answer;

            Console.WriteLine($"Result 1 : {result1.Value}");
            Console.WriteLine($"Result 2 : {result2.Value}");
            Console.WriteLine($"Result 3 : {result3.Value}");
            Console.WriteLine($"Result 4 : {result4.Value}");
            Console.WriteLine($"Result 5 : {result5.Value}");

            Console.Read();

            system.Terminate();
        }
    }
}