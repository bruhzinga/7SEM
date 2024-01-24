using System;
using System.Net;

namespace PWS_3.Exceptions
{
    public abstract class BaseException : Exception
    {
        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        public abstract int SubCode { get;}
        
        public abstract string Description { get;}
        
        public BaseException(string message) : base(message)
        {
        }

        public BaseException()
        {
        }
    }
}