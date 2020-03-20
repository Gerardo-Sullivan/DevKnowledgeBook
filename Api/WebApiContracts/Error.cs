using System;

namespace WebApiContracts
{
    /// <summary>
    /// Standard Error object model for the DevKnowledgebase Web Api
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error type
        /// </summary>
        public ErrorType Type { get; set; }

        public Error(string errorMessage, ErrorType errorType)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException($"{nameof(errorMessage)} cannot be null or empty.");
            }

            Message = errorMessage;
            Type = errorType;
        }
    }
}
