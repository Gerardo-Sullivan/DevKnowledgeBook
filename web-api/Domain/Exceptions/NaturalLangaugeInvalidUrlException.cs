using System;

namespace Domain.Exceptions
{
    public class NaturalLangaugeInvalidUrlException : Exception
    {
        public string InvalidUrl { get; }

        public NaturalLangaugeInvalidUrlException(string message, string invalidUrl) : base(message)
        {
            InvalidUrl = invalidUrl;
        }

        public NaturalLangaugeInvalidUrlException(string message, string invalidUrl, Exception innerException) : base(message, innerException)
        {
            InvalidUrl = invalidUrl;
        }
    }
}
