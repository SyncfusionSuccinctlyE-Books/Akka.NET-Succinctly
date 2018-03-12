using System;
using Akka.Actor;

namespace Akka.Net.Succinctly.Chapter5
{
    public class EmailSenderActor : ReceiveActor
    {
        public EmailSenderActor()
        {
            Console.WriteLine($"Constructor() -> EmailSenderActor");

            Receive<EmailMessage>(message => HandleEmailMessage(message));
        }

        private void HandleEmailMessage(EmailMessage message)
        {
            if (string.IsNullOrEmpty(message.Content))
            {
                throw new ArgumentException("Cannot handle the empty content");
            }
            Console.WriteLine($"email sent from {message.From} to {message.To} with content {message.Content}");
        }

        protected override void PreStart()
        {
            Console.WriteLine("PreStart() -> EmailSenderActor");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("PreRestart() -> EmailSenderActor");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("PostRestart() -> EmailSenderActor");
            base.PostRestart(reason);
        }

        protected override void PostStop()
        {
            Console.WriteLine("PostStop() -> EmailSenderActor");
        }
        protected override void Unhandled(object message)
        {
            base.Unhandled(message);
        }
    }
}