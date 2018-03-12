using System;
using Akka.Actor;
using Akka.DI;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Autofac;


namespace Akka.Net.Succinctly.DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and build your container
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterType<MusicSongService>().As<IMusicSongService>();
            builder.RegisterType<MusicActor>().AsSelf();
            var container = builder.Build();

            // Create the ActorSystem and Dependency Resolver
            var system = ActorSystem.Create("MySystem");
            var propsResolver = new AutoFacDependencyResolver(container, system);


            IActorRef musicActor = system.ActorOf(system.DI().Props<MusicActor>(), "MusicActor");

            musicActor.Tell("Bohemian Rapsody");

            Console.Read();
            system.Terminate();
        }
    }
}