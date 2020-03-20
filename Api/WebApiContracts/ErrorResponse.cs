using System;

namespace WebApiContracts
{
    /// <summary>
    /// Standard Error Response model for the DevKnowledgebase Web Api
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Request sent by the client
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Time error occured
        /// </summary>
        public DateTimeOffset ErrorTime { get; set; }

        /// <summary>
        /// Type of Error
        /// </summary>
        public Error Error { get; set; }

        public ErrorResponse(string request, Error error, DateTimeOffset errorTime)
        {
            if (string.IsNullOrEmpty(request))
            {
                throw new ArgumentNullException($"{nameof(request)} cannot be null or empty.");
            }

            Request = request;
            ErrorTime = errorTime;
            Error = error;
        }

        public ErrorResponse(string request, string errorMessage, ErrorType errorType) :
            this(request, new Error(errorMessage, errorType))
        {
        }

        public ErrorResponse(string request, Error error) : this(request, error, DateTime.UtcNow)
        {
        }
    }
}
