using Akka.Actor;
using System;

namespace Akka.Net.Succinctly.Chapter4
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicActorCreationUsingTell();

            BasicActorCreationUsingAsk();

            BasicActorCreationUsingAsyncAwaitPattern();

            BasicActorCreationUsingAsyncAwaitPatternWithAny();

            Console.ReadLine();
        }

        static void BasicActorCreationUsingTell()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef untypedActor = system.ActorOf<MyUntypedActor>("untyped-actor-name");
            IActorRef typedActor = system.ActorOf<MyTypedActor>("typed-actor-name");

            untypedActor.Tell(new GreetingMessage("Hello untyped actor!"));
            typedActor.Tell(new GreetingMessage("Hello typed actor!"));
            Console.Read();
            system.Terminate();
        }

        static void BasicActorCreationUsingAsyncAwaitPattern()
        {
            ActorSystem system = ActorSystem.Create("html-download-system");

            IActorRef receiveAsyncActor = system.ActorOf<DownloadHtmlActor>("typed-actor-name");

            receiveAsyncActor.Tell("https://www.agile-code.com");
            receiveAsyncActor.Tell("https://www.microsoft.com");
            receiveAsyncActor.Tell("https://www.syncfusion.com");

            Console.Read();
            system.Terminate();
        }

        static void BasicActorCreationUsingAsyncAwaitPatternWithAny()
        {
            ActorSystem system = ActorSystem.Create("html-download-system");

            IActorRef receiveAsyncActor = system.ActorOf<DownloadAnyHtmlActor>();

            receiveAsyncActor.Tell("https://www.agile-code.com");
            receiveAsyncActor.Tell(new Uri("https://www.syncfusion.com"));
            receiveAsyncActor.Tell(new GreetingMessage("hi"));

            Console.Read();
            system.Terminate();
        }

        static void BasicActorCreationUsingAsk()
        {
            ActorSystem system = ActorSystem.Create("calc-system");

            IActorRef calculator = system.ActorOf<CalculatorActor>("calculator");

            Answer result = calculator.Ask<Answer>(new Add(1, 2)).Result;

            Console.WriteLine("Addition result: " + result.Value);
            Console.Read();
            system.Terminate();
        }
    }
}