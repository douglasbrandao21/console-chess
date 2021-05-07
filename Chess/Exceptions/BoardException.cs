using System;

namespace Exceptions
{
    class BoardException : ApplicationException
    {
        public BoardException(string message) : base(message) { }
    }
}
