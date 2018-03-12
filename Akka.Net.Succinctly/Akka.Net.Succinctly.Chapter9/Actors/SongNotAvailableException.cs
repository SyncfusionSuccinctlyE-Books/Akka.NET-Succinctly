using System;

namespace Akka.Net.Succinctly.Chapter9.Actors
{
    public class SongNotAvailableException : Exception
    {
        public SongNotAvailableException(string message) : base(message)
        {

        }
    }
}