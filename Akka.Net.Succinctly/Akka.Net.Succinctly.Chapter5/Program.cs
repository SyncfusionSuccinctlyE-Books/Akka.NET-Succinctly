using Akka.Actor;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Chapter5
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowTheLifeCycleOfAnActor();

            //TerminateBySendingPoisonPillMessage();

            //TerminateBySendingTheKillMessage();

            //TerminateByUsingStop();

            //RestartingAnActorByUsingTheDefaultSupervisionStrategy();

            TerminateByUsingGracefulStop();
            Console.Read();
        }

        private async static Task TerminateByUsingGracefulStop()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");

            EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

            emailSender.Tell(emailMessage);
            var result = emailSender.GracefulStop(TimeSpan.FromSeconds(10));
            Thread.Sleep(1000);
            system.Terminate();
        }

        static void ShowTheLifeCycleOfAnActor()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");

            EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

            emailSender.Tell(emailMessage);

            Thread.Sleep(1000);
            system.Terminate();
        }

        static void TerminateBySendingPoisonPillMessage()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");

            EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

            emailSender.Tell(emailMessage);
            emailSender.Tell(emailMessage);
            emailSender.Tell(PoisonPill.Instance);
            emailSender.Tell(emailMessage);

            Thread.Sleep(1000);
            system.Terminate();
        }

        static void TerminateBySendingTheKillMessage()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");

            EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

            emailSender.Tell(emailMessage);
            emailSender.Tell(emailMessage);
            emailSender.Tell(Kill.Instance);
            emailSender.Tell(emailMessage);

            Thread.Sleep(1000);
            system.Terminate();
        }

        static void TerminateByUsingStop()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");

            EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

            emailSender.Tell(emailMessage);

            system.Stop(emailSender);

            system.Terminate();
        }

        static void RestartingAnActorByUsingTheDefaultSupervisionStrategy()
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");

            //send an invalid message (null content)
            EmailMessage invalidEMail = new EmailMessage("from@mail.com", "to@mail.com", null);
            EmailMessage validEmail = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

            emailSender.Tell(validEmail);
            emailSender.Tell(invalidEMail);

            emailSender.Tell(validEmail);

            Console.Read(); //let's pause...
            system.Terminate();

        }
    }
}
