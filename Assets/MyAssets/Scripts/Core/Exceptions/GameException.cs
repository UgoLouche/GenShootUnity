using System;

namespace GenShootUnity.Core.Exceptions
{
    class GameException : Exception
    {
        public GameException() : base() { }
        public GameException(string message) : base(message) { }
    }
}
