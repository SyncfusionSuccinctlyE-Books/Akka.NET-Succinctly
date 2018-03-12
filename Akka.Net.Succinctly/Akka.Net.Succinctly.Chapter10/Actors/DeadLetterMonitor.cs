using System;
using Akka.Actor;
using Akka.Event;

namespace Akka.Net.Succinctly.Chapter10.Actors
{
    public class DeadLetterMonitor : ReceiveActor
    {
        public DeadLetterMonitor()
        {
            Receive<DeadLetter>(x => Handle(x));
        }

        private void Handle(DeadLetter deadLetter)
        {
            var msg = $"message: {deadLetter.Message}, \n" +
                      $"sender:  {deadLetter.Sender},  \n" +
                      $"recipient: {deadLetter.Recipient}\n";

            Console.WriteLine(msg);
        }
    }
}