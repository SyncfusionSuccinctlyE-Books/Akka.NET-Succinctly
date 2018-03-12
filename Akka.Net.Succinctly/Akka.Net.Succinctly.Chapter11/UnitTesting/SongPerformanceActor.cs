using Akka.Actor;
using System;
using System.Collections.Generic;

namespace Akka.Net.Succinctly.Chapter11.UnitTesting
{
    public class SongPerformanceActor : ReceiveActor
    {
        public Dictionary<string, int> SongPeformanceCounter;

        public SongPerformanceActor()
        {
            SongPeformanceCounter = new Dictionary<string, int>();

            Receive<PlaySongMessage>(m => IncreaseSongCounter(m));
        }

        public void IncreaseSongCounter(PlaySongMessage m)
        {
            var counter = 1;
            if (SongPeformanceCounter.ContainsKey(m.Song))
            {
                counter = SongPeformanceCounter[m.Song]++;
            }
            else
            {
                SongPeformanceCounter.Add(m.Song, counter);
            }

            Sender.Tell(new CounterIncreasedMessage(m.Song, counter));
        }
    }
}