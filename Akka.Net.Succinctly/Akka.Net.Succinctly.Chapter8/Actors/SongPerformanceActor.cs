using Akka.Actor;
using Akka.Net.Succinctly.Chapter8.Messages;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Akka.Net.Succinctly.Chapter8.Actors
{
    public class SongPerformanceActor : ReceiveActor
    {
        protected Dictionary<string, int> SongPeformanceCounter;

        public SongPerformanceActor()
        {
            SongPeformanceCounter = new Dictionary<string, int>();

            Receive<PlaySongMessage>(m => IncreaseSongCounter(m));
        }

        private void IncreaseSongCounter(PlaySongMessage m)
        {
            int counter = 1;
            if (SongPeformanceCounter.ContainsKey(m.Song))
            {
                counter = SongPeformanceCounter[m.Song];
                counter++;
                SongPeformanceCounter[m.Song] = counter;
            }
            else
            {
                SongPeformanceCounter.Add(m.Song, counter);
            }

            Console.WriteLine($"Song: {m.Song} has been played {counter} times");
        }
    }
}