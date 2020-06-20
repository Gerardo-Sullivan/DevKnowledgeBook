using System;

namespace WebApi.Exceptions
{
    public class NoBookmarkExitsException : Exception
    {
        public string RequestUrl { get; }

        public NoBookmarkExitsException(string message, string requestUrl) : base(message)
        {
            RequestUrl = requestUrl;
        }
    }
}
