using Microsoft.Extensions.Logging;
using SIS.Domain.Exceptions.Common;
using SIS.Domain.Exceptions.Database;

namespace SIS.Common
{
    public class CommonUtils
    {
        public static void EnsureDbSaveSucceeded<T>(int result, string action, string entityName, ILogger<T> logger)
        {
            if (result <= 0)
            {
                logger.LogWarning("Action {Action} failed for entity: {Entity}.", action, entityName);
                throw new DbNoChangeSavedException(action, entityName);
            }

            logger.LogInformation("Action {Action} succeeded for entity: {Entity}.", action, entityName);
        }

        public static void EnsureObjectNotNull<T>(object obj, string entityName, ILogger<T> logger)
        {
            if (obj == null)
            {
                logger.LogWarning("The object is null: {Entity}", entityName);
                throw new InvalidInputException($"The object cannot be null: {entityName}.");
            }
        }

        public static void EnsureStringNotNullOrEmpty<T>(string str, string paramName, ILogger<T> logger)
        {
            if (string.IsNullOrEmpty(str))
            {
                logger.LogWarning("The string is null or empty: {ParamName}", paramName);
                throw new InvalidInputException($"The string cannot be null or empty: {paramName}.");
            }
        }

        public static void EnsureIdIsValid(int id, string entityName)
        {
            if (id <= 0)
                throw new InvalidInputException($"Invalid Id of {entityName}.");
        }
    }
}
