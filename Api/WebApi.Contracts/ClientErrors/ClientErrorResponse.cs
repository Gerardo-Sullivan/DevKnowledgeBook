using System;

namespace WebApi.Contracts.ClientErrors
{
    /// <summary>
    /// Standard Error Response model for the DevKnowledgebase Web Api
    /// </summary>
    public class ClientErrorResponse //TODO: perhaps are more useful properties
    {
        /// <summary>
        /// Request sent by the client
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Time error occured
        /// </summary>
        public DateTimeOffset ErrorTime { get; set; } //TODO: change this name

        /// <summary>
        /// Type of Error
        /// </summary>
        public Error Error { get; set; }

        public ClientErrorResponse(string request, Error error, DateTimeOffset errorTime)
        {
            if (string.IsNullOrEmpty(request))
            {
                throw new ArgumentNullException($"{nameof(request)} cannot be null or empty.");
            }

            Request = request;
            ErrorTime = errorTime;
            Error = error;
        }

        public ClientErrorResponse(string request, string errorMessage, ClientErrorType errorType) :
            this(request, new Error(errorMessage, errorType))
        {
        }

        public ClientErrorResponse(string request, Error error) : this(request, error, DateTime.UtcNow)
        {
        }
    }
}
