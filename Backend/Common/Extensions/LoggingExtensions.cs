using Microsoft.Extensions.Logging;

namespace SIS.Common.Extensions
{
    public static class LoggingExtensions
    {
        public static void LogFoundOrNot<T, TLogger>(this ILogger<TLogger> logger, T? entity, string keyName, object keyValue)
        {
            if (entity == null)
                logger.LogWarning("{Entity} with {Key} {Value} not found.", typeof(T).Name, keyName, keyValue);
            else
                logger.LogInformation("Successfully retrieved {Entity} with {Key}: {Value}", typeof(T).Name, keyName, keyValue);
        }
    }
}
