using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Common.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogTraceObject<T>(this ILogger logger, T objectToLog)
        {
            var logObject = new LogObject<T>(objectToLog);
            var logObjectJson = JsonSerializer.Serialize(logObject);
            logger.LogTrace(logObjectJson);
        }
    }

    public class LogObject<T>
    {
        public string ObjectName { get; set; }
        public T Object { get; set; }

        public LogObject(T logObject)
        {
            ObjectName = nameof(logObject);
            Object = logObject;
        }
    }
}
