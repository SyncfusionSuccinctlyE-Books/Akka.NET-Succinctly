using NUnit.Framework;
using System.Linq;

namespace Akka.Net.Succinctly.Chapter11.DirectTesting
{
    [TestFixture]
    public class SongPerformanceActorTest : Akka.TestKit.NUnit.TestKit
    {
        [Test]
        public void ShouldStartWithAnEmptyState()
        {
            var actor = new SongPerformanceActor();

            Assert.False(actor.SongPeformanceCounter.Any());
        }

        [Test]
        public void ShouldIncreaseSongByOne()
        {
            var actor = new SongPerformanceActor();

            var songMessage = new PlaySongMessage("Bohemian Rapsody", "John");

            actor.IncreaseSongCounter(songMessage);

            Assert.True(actor.SongPeformanceCounter[songMessage.Song] == 1);
        }
    }
}