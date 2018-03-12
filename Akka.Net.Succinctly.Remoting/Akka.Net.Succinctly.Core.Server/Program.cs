using Akka.Actor;
using Akka.Configuration;
using Akka.Net.Succinctly.Core.Common;
using System;

namespace Akka.Net.Succinctly.Core.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var hocon = HoconLoader.FromFile("akka.net.hocon");
            ActorSystem system = ActorSystem.Create("server-system", hocon);

            Console.WriteLine("Server started");

            Console.Read();
            system.Terminate().Wait();
        }
    }
}