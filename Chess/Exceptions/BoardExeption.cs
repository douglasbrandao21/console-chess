using System;

namespace Exceptions
{
    class BoardExeption : ApplicationException
    {
        public BoardExeption(string message) : base(message) { }
    }
}
