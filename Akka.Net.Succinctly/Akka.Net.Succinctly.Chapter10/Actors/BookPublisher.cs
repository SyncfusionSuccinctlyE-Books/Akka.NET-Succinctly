using Akka.Actor;
using Akka.Net.Succinctly.Chapter10.Actors.Messages;

namespace Akka.Net.Succinctly.Chapter10.Actors
{
    public class BookPublisher : ReceiveActor
    {
        public BookPublisher()
        {
            Receive<NewBookMessage>(x => Handle(x));
        }

        protected override void PreStart()
        {
            base.PreStart();
        }

        private void Handle(NewBookMessage x)
        {
            Context.System.EventStream.Publish(x);
        }
    }
}