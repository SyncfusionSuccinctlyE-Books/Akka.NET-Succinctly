using NUnit.Framework;
using System.Linq;
using Akka.TestKit;
using Akka.Actor;
using System;

namespace Akka.Net.Succinctly.Chapter11.UnitTesting
{
    [TestFixture]
    public class SongPerformanceActorTest : Akka.TestKit.NUnit.TestKit
    {
        [Test]
        public void ShouldIncreaseSongByOneViaActorSystem()
        {
            TestActorRef<SongPerformanceActor> actor = ActorOfAsTestActorRef<SongPerformanceActor>();

            var songMessage = new PlaySongMessage("Bohemian Rapsody", "John");

            actor.Tell(songMessage);

            Assert.True(actor.UnderlyingActor.SongPeformanceCounter[songMessage.Song] == 1);
        }

        [Test]
        public void ShouldResendCounterIncreasedMessage()
        {
            TestActorRef<SongPerformanceActor> actor = ActorOfAsTestActorRef<SongPerformanceActor>();

            var songMessage = new PlaySongMessage("Bohemian Rapsody", "John");

            actor.Tell(songMessage);

            /* 
                * specify the actor explicitly
                * CounterIncreasedMessage replyMessage = ExpectMsgFrom<CounterIncreasedMessage>(actor);
            */

            CounterIncreasedMessage counter = ExpectMsg<CounterIncreasedMessage>(TimeSpan.FromSeconds(5));

            Assert.That(counter.Song == "Bohemian Rapsody");
            Assert.That(counter.Count == 1);
        }
    }
}