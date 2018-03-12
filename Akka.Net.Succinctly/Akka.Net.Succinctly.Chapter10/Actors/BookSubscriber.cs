using System;
using Akka.Actor;
using Akka.Net.Succinctly.Chapter10.Actors.Messages;

namespace Akka.Net.Succinctly.Chapter10.Actors
{
    public class BookSubscriber : ReceiveActor
    {
        public BookSubscriber()
        {
            Receive<NewBookMessage>(x => HandleNewBookMessage(x));
        }

        private void HandleNewBookMessage(NewBookMessage book)
        {
            Console.WriteLine($"Book: {book.BookName} got published - message received by {Self.Path.Name}!");
        }
    }
}