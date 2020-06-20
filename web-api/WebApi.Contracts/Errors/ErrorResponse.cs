using System;
using System.Net;

namespace WebApi.Contracts.Errors
{
    /// <summary>
    /// Standard Error Response model for the DevKnowledgeBook Web Api
    /// </summary>
    public class ErrorResponse //TODO: perhaps add more useful properties
    {
        /// <summary>
        /// Request sent by the client that caused an error
        /// </summary>
        public string Request { get; }

        /// <summary>
        /// Integer value of error's <see cref="HttpStatusCode"/>
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Title of the error
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Description of the error
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Code for the error
        /// </summary>
        public int? ErrorCode { get; }

        /// <summary>
        /// Time error occurred
        /// </summary>
        public DateTimeOffset ErrorTime { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class with the
        /// request, http status code, title, description and error time of the error.
        /// </summary>
        public ErrorResponse(
            string request,
            HttpStatusCode statusCode,
            string title,
            string description,
            DateTimeOffset errorTime
        )
        {
            if (string.IsNullOrEmpty(request))
            {
                throw new ArgumentNullException($"{nameof(request)} cannot be null or empty.");
            }

            Request = request;
            StatusCode = (int)statusCode;
            Title = title;
            Description = description;
            ErrorTime = errorTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class with the
        /// request, http status code, title and description of the error.
        /// </summary>
        public ErrorResponse(
            string request,
            HttpStatusCode statusCode,
            string title,
            string description
        ) : this(
            request,
            statusCode,
            title,
            description,
            DateTime.UtcNow
        )
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class with the
        /// request, http status code, title, description, error code and error time of the error.
        /// </summary>
        public ErrorResponse(
            string request,
            HttpStatusCode statusCode,
            string title,
            string description,
            int errorCode,
            DateTimeOffset errorTime
        ) : this(
            request,
            statusCode,
            title,
            description,
            errorTime
        )
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class with the
        /// request, http status code, title, description and error code of the error.
        /// </summary>
        public ErrorResponse(
            string request,
            HttpStatusCode statusCode,
            string title,
            string description,
            int errorCode
        ) : this(
            request,
            statusCode,
            title,
            description,
            errorCode,
            DateTime.UtcNow
        )
        { }
    }
}
