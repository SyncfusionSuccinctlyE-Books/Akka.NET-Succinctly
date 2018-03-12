using Akka.Actor;
using Akka.TestKit;
using NUnit.Framework;
using System;

namespace Akka.Net.Succinctly.Chapter11.IntegrationTesting
{
    [TestFixture]
    public class MusicPlayerCoordinatorActorTest : Akka.TestKit.NUnit.TestKit
    {
        [Test]
        public void ShouldInstantiateANewChildActor()
        {
            TestActorRef<MusicPlayerCoordinatorActor> actor =
                ActorOfAsTestActorRef(() => new MusicPlayerCoordinatorActor(), "Coordinator");

            var songMessage = new PlaySongMessage("Bohemian Rapsody", "John");

            actor.Tell(songMessage);

            IActorRef child = this.Sys.ActorSelection("/user/Coordinator/John")
                .ResolveOne(TimeSpan.FromSeconds(5))
                .Result;

            Assert.That(child != null);
        }

        [Test]
        public void Parent_should_create_child()
        {
            // verify child has been created by sending parent a message
            // that is forwarded to child, and which child replies to sender with
            var parentProps = Props.Create(() => new MusicPlayerCoordinatorActor());
            var coordinator = ActorOfAsTestActorRef<MusicPlayerCoordinatorActor>(parentProps, TestActor);

            var songMessage = new PlaySongMessage("Bohemian Rapsody", "John");

            coordinator.Tell(songMessage);
            ExpectMsg("Item received");
        }
    }
}