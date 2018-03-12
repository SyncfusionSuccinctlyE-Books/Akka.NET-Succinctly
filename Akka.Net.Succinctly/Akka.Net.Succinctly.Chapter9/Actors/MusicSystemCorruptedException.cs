using System;

namespace Akka.Net.Succinctly.Chapter9.Actors
{
    public class MusicSystemCorruptedException : Exception
    {
        public MusicSystemCorruptedException(string message) : base(message)
        {

        }
    }
}