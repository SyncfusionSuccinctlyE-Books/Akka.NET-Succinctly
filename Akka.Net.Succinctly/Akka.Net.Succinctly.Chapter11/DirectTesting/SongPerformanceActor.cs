using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Net.Succinctly.Chapter11.DirectTesting
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
            if (SongPeformanceCounter.ContainsKey(m.Song))
            {
                SongPeformanceCounter[m.Song]++;
            }
            else
            {
                SongPeformanceCounter.Add(m.Song, 1);
            }
        }
    }
}